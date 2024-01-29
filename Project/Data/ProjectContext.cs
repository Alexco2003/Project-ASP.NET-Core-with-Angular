using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mysqlx.Session;
using Project.Models;
using System.Xml.Linq;


namespace Project.Data
{
    public class ProjectContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie_Review_> Reviews { get; set; }

        public ProjectContext (DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // One to One, User-Subscription
            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithOne(s => s.User)
                .HasForeignKey<Subscription>(s => s.UserId);
            
            // One to Many, Subscription-Movie
            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.Movies)
                .WithOne(m => m.Subscription)
                .HasForeignKey(m => m.SubscriptionId);
            
            // Many to Many, User-Movie (UserMovie(Review))
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);
        }   
    }
}
