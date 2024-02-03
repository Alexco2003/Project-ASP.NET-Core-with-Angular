using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Project.Data;
using Project.Models;

namespace Project.Helpers.Seeders
{
    public class UserSubscriptionMoviesSeeder
    {
        public readonly ProjectContext _context;

        public UserSubscriptionMoviesSeeder(ProjectContext context)
        {
            _context = context;
        }

        public void SeedInitialUser()
        {
            if (!_context.Users.Any())
            {
                var hasher = new PasswordHasher<User>();
                var users = new List<User>()
                {
                    new User()
                    {
                        Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a1"),
                        UserName = "Alexco2003",
                        NormalizedUserName = "Alexco2003".ToUpper(),
                        Email = "alexco2003@gmail.com",
                        NormalizedEmail = "alexco2003@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Alexco1234"),
                        SecurityStamp = Guid.NewGuid().ToString(),


                        FirstName = "Codarcea",
                        LastName = "Alexandru",
                        PhoneNumber = "0724318500",
                        Age = 20,
                        Budget = 99999999,

                        Subscription = new Subscription
                        {
                            Name = "Premium",
                            Description = "The best subscription",
                            Price = 50,
                            Movies = new List<Movie>
                            {
                                new Movie
                                {
                                    Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a2"),
                                    Name = "The Godfather",
                                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                                    Duration = 175,
                                    UserScore = 9.2f,
                                    MPARating = "R",

                                },
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a3"),
                                    Name = "The Shawshank Redemption",
                                    Description = "Two imprisoned",
                                    Duration = 142,
                                    UserScore = 9.3f,
                                    MPARating = "R",
                                },
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a4"),
                                    Name = "The Dark Knight",
                                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                                    Duration = 152,
                                    UserScore = 9.7f,
                                    MPARating = "PG-13",
                                },
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a5"),
                                    Name = "The Godfather: Part II",
                                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                                    Duration = 202,
                                    UserScore = 9.0f,
                                    MPARating = "R",
                                }



                            }

                        },


                    },

                    new User()
                    {
                        Id = new Guid("aeb1d17a-f966-4089-a5b8-f28ce98d4e28"),
                        UserName = "GFA",
                        NormalizedUserName = "GFA".ToUpper(),
                        Email = "gfa03@yahoo.com",
                        NormalizedEmail = "gfa03@yahoo.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "36killspecs"),
                        SecurityStamp = Guid.NewGuid().ToString(),

                        FirstName = "Gavrila",
                        LastName = "Alexandru",
                        PhoneNumber = "0724347825",
                        Age = 20,
                        Budget = 30,

                        Subscription = new Subscription
                        {
                            Name = "Standard",
                            Description = "The standard subscription",
                            Price = 10,
                            Movies = new List<Movie>
                            {

                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a6"),
                                    Name = "Aquaman",
                                    Description = "Arthur Curry, the human-born heir to the underwater kingdom of Atlantis, goes on a quest to prevent a war between the worlds of ocean and land.",
                                    Duration = 142,
                                    UserScore = 7.3f,
                                    MPARating = "R",
                                },
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a9"),
                                    Name = "Hello Kitty",
                                    Description= "The story of Hello Kitty.",
                                    Duration = 152,
                                    UserScore = 9.7f,
                                    MPARating = "PG-13",
                                }



                            }
                        }


                    },

                    new User()
                    {
                        Id = new Guid("3cc80f65-2fc3-407d-b9d5-7be0b1439a08"),
                        UserName = "Patzi",
                        NormalizedUserName = "Patzi".ToUpper(),
                        Email = "patzi210@gmail.com",
                        NormalizedEmail = "patzi210@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "COXDragne"),
                        SecurityStamp = Guid.NewGuid().ToString(),

                        PhoneNumber = "0753674756",
                        FirstName = "Patilea",
                        LastName = "Calin",
                        Age = 54,
                        Budget = 170,

                        Subscription = new Subscription
                        {
                            Name = "Art",
                            Description = "The Art subscription",
                            Price = 100,
                            Movies = new List<Movie>
                            {
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a7"),
                                    Name = "Isle of Dogs",
                                    Description = "A pack of alpha dogs help a young",
                                    Duration = 132,
                                    UserScore = 8.5f,
                                    MPARating = "R",
                                },
                                new Movie
                                {   Id = new Guid("a777c9f3-6811-4bb6-bb20-352bdd9f00a8"),
                                    Name = "Dracula",
                                    Description = "The ancient vampire Count Dracula arrives in England and begins to prey upon the virtuous young Mina.",
                                    Duration = 142,
                                    UserScore = 3.3f,
                                    MPARating = "R",
                                }

                            }
                        }



                    }
                };

                _context.Users.AddRange(users);

                _context.SaveChanges();
            }
        }
    }
}
