using AutoMapper;
using Project.Models.DTOs.SubscriptionDTOs;
using Project.Repositories.SubscriptionRepository;
using Project.Repositories.UserRepository;

namespace Project.Services.SubscriptionService
{
    public class SubscriptionService: ISubscriptionService
    {
        public ISubscriptionRepository _SubscriptionRepository;
        public IUserRepository _userRepository;
        public IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository SubscriptionRepository,
                                IMapper mapper,
                                IUserRepository userRepository)
        {
            _SubscriptionRepository = SubscriptionRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateSubscription(SubscriptionCreateDTO Subscription)
        {
            var user = await _userRepository.GetUserById(Subscription.UserId);
            if (user.Subscription != null)
            {
                throw new Exception("User already has a Subscription!");
            }

            var newSubscription = _mapper.Map<Project.Models.Subscription>(Subscription);
            newSubscription.Id = Guid.NewGuid();
            newSubscription.UserId = user.Id;
            newSubscription.User = user;
            user.Subscription = newSubscription;

            _userRepository.Update(user);

            _SubscriptionRepository.Create(newSubscription);
            await _SubscriptionRepository.SaveAsync();
        }

        public async Task<SubscriptionFormattedDTO>? GetSubscriptionByUsername(string username)
        {
            var userDTO = await _userRepository.GetByUsername(username);
            if (userDTO == null)
            {
                throw new Exception("Invalid User!");
            }
            var prof = _SubscriptionRepository.GetSubscriptionByUserId(userDTO.Id);
            var profMapped = _mapper.Map<SubscriptionFormattedDTO>(prof);

            if (profMapped != null)
            {
                profMapped.Name = userDTO.UserName;
                return profMapped;
            }

            throw new Exception("User doesn't have a Subscription yet!");
        }

        public async Task UpdateSubscription(SubscriptionUpdateDTO Subscription)
        {
            var existingSubscription = await _SubscriptionRepository.FindByIdAsync(Subscription.Id);

            if (existingSubscription == null)
            {
                throw new Exception("User not found!");
            }

            Subscription.LastModified = DateTime.Now;
            if (Subscription.Name != null) 
            { existingSubscription.Name = Subscription.Name; }
                

            if (Subscription.Description != null)
            { existingSubscription.Description = Subscription.Description; }

            if (Subscription.Price != null)
            { existingSubscription.Price = (int)Subscription.Price; }

            _SubscriptionRepository.Update(_mapper.Map<Project.Models.Subscription>(existingSubscription));
            await _SubscriptionRepository.SaveAsync();
        }
    }
}
