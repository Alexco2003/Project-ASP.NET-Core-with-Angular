using Project.Models.DTOs.SubscriptionDTOs;

namespace Project.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<SubscriptionFormattedDTO>? GetSubscriptionByUsername(string username);
        Task UpdateSubscription(SubscriptionUpdateDTO subscription);
        Task CreateSubscription(SubscriptionCreateDTO subscription);
    }
}
