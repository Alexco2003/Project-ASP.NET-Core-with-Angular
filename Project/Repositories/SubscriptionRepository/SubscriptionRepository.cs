using AutoMapper;
using Project.Data;
using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.SubscriptionRepository
{
    public class SubscriptionRepository: GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ProjectContext context) : base(context) { }

        public Subscription? GetSubscriptionByUserId(Guid userId)
        {
            return _table.FirstOrDefault(s => s.UserId == userId);
        }
    }
}
