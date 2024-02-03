using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Mysqlx.Session;
using Project.Models.DTOs.UserDTOs;
using Project.Models.DTOs;
using Project.Models;
using System.Xml.Linq;
using Project.Models.DTOs.SubscriptionDTOs;
using Project.Models.DTOs.MovieDTOs;
using Project.Models.DTOs.UserMovie_Review_DTOs;

namespace Project.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            var hasher = new PasswordHasher<User>();

            // User
            CreateMap<User, UserActionDTO>();

            CreateMap<User, UserCreateDTO>();
            CreateMap<User, UserUpdateDTO>();

            CreateMap<User, UserFormattedDTO>();
            CreateMap<UserFormattedDTO, User>();

            CreateMap<UserUpdateDTO, User>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<SignUpDTO, User>()
                .ForMember(u => u.Id, opt =>
                    opt.MapFrom(src => new Guid()))
                .ForMember(u => u.PasswordHash, opt =>
                    opt.MapFrom(src => hasher.HashPassword(null, src.Password)))
                .ForMember(u => u.LockoutEnabled, opt =>
                    opt.MapFrom(src => false))
                .ForMember(u => u.SecurityStamp, opt =>
                    opt.Ignore());

            // Subscription
            CreateMap<Subscription, SubscriptionFormattedDTO>();
            CreateMap<SubscriptionFormattedDTO, Subscription>();

            CreateMap<Subscription, SubscriptionUpdateDTO>();
            CreateMap<SubscriptionUpdateDTO, Subscription>();

            CreateMap<Subscription, SubscriptionCreateDTO>();
            CreateMap<SubscriptionCreateDTO, Subscription>();

            // Movies
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<Movie, MovieCreateDTO>();

            CreateMap<MovieShownDTO, Movie>();
            CreateMap<Movie, MovieShownDTO>();

            // Reviews

            CreateMap<UserMovie_Review_, UserMovie_Review_Create>();
            CreateMap<UserMovie_Review_Create, UserMovie_Review_>();

            
        }

    }
}
