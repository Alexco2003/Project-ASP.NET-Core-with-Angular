using Microsoft.AspNetCore.Identity;
using Project.Data;

namespace Project.Helpers.Seeders
{
    public class UserRoleSeeder
    {
        public readonly ProjectContext _context;

        public UserRoleSeeder(ProjectContext context)
        {
            _context = context;
        }
        public void SeedInitialUserRoles()
        {
            if (!_context.UserRoles.Any())
            {
                var user_roles = new List<IdentityUserRole<Guid>>()
                {
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = new Guid("87c63ad73e24447a8e60a1d814abaa78"),
                        UserId = new Guid("A777C9F3-6811-4BB6-BB20-352BDD9F00A1")

                    },
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = new Guid("1b2fe19c191441048294d308fd98e44d"),
                        UserId = new Guid("3CC80F65-2FC3-407D-B9D5-7BE0B1439A08")
                    },
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = new Guid("1b2fe19c191441048294d308fd98e44d"),
                        UserId = new Guid("AEB1D17A-F966-4089-A5B8-F28CE98D4E28")
                    },
                };

                _context.UserRoles.AddRange(user_roles);
                _context.SaveChanges();
            }
        }
    }
}
