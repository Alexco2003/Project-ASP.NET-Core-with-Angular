using Microsoft.AspNetCore.Identity;
using Project.Data;

namespace Project.Helpers.Seeders
{
    public class RolesSeeder
    {
        public readonly ProjectContext _context;

        public RolesSeeder(ProjectContext context)
        {
            _context = context;
        }
        public void SeedInitialRoles()
        {
            if (!_context.Roles.Any())
            {
                var role1 = new List<IdentityRole<Guid>>()
                {
                    new IdentityRole<Guid>()
                    {
                        Id = new Guid("87c63ad73e24447a8e60a1d814abaa78"),
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    },
                    new IdentityRole<Guid>()
                    {
                        Id = new Guid("1b2fe19c191441048294d308fd98e44d"),
                        Name = "User",
                        NormalizedName = "User".ToUpper()
                    },
                    new IdentityRole<Guid>()
                    {
                        Id = new Guid("dfc9ac4f-b7e8-4144-95ba-0952eede041e"),
                        Name = "Investor",
                        NormalizedName = "Investor".ToUpper()
                    }

                };

                _context.Roles.AddRange(role1);
                _context.SaveChanges();
            }
        }
    }
}
