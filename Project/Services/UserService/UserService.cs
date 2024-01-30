using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.Models.DTOs;
using Project.Models.Responses;
using Project.Models;
using Project.Repositories.UserRepository;
using Project.Models.DTOs.UserDTOs;

namespace Project.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserFormattedDTO> GetUserById(Guid id)
        {
            return _mapper.Map<UserFormattedDTO>(await _userRepository.GetUserById(id));

        }
        public async Task<UserFormattedDTO> GetUserByUsername(string username)
        {
            return _mapper.Map<UserFormattedDTO>(await _userRepository.GetByUsername(username));
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task Update(UserUpdateDTO user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found!");

            }
            if (user.UserName != null && user.UserName != "")
                existingUser.UserName = user.UserName;

            if (user.Email != null && user.Email != "")
                existingUser.Email = user.Email;

            if (user.PhoneNumber != null && user.PhoneNumber != "")
                existingUser.PhoneNumber = user.PhoneNumber;

            if (user.Password != null && user.Password != "")
            {
                var hasher = new PasswordHasher<User>();
                existingUser.PasswordHash = hasher.HashPassword(null, user.Password);
            }
            _userRepository.Update(_mapper.Map<User>(existingUser));

        }

        public async Task<UserFormattedDTO> CreateAsync(UserCreateDTO user)
        {
            var newUser = _mapper.Map<User>(user);
            await _userRepository.CreateAsync(newUser);
            return _mapper.Map<UserFormattedDTO>(newUser);

        }

        public async Task<Guid> Login(LoginDTO login)
        {
            var userUsername = await _userManager.FindByNameAsync(login.UserName);
            var userEmail = await _userManager.FindByEmailAsync(login.Email);

            if (userUsername != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(userUsername, login.Password, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(userUsername, isPersistent: true);

                    return userUsername.Id;
                }
            }
            else
            {
                if (userEmail != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(userEmail, login.Password, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(userEmail, isPersistent: true);

                        return userEmail.Id;
                    }
                }
            }
            throw new Exception("User not found!");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ErrorResponse> SignUp(SignUpDTO signUpDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(signUpDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists!");
            }

            var user = _mapper.Map<User>(signUpDto);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, "User");

                return new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Successful registration!"
                };
            }

            throw new Exception(result.Errors.First().Description);
        }
    }
}
