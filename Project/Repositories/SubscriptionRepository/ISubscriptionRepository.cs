using AutoMapper;
using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.SubscriptionRepository
{
    public interface ISubscriptionRepository: IGenericRepository<Subscription>
    {
        Subscription? GetSubscriptionByUserId(Guid userId);
    }
}
