using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class ApplicationUsersIdentity : IdentityUser
    {
        [StringLength(14)]
        public string NationalID { get; set; }
        public string City { get; set; }
        public string RoleName { get; set; }
    }

    public class ApplicationUserStore : UserStore<ApplicationUsersIdentity>
    {

        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }
    public class ApplicationDBContext : IdentityDbContext<ApplicationUsersIdentity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Data Source=.;Initial Catalog=HotelReservation;Integrated Security=True"
               , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
  

        public DbSet<MealPlans> MealPlans { get; set; }
        public DbSet<MealPlansInSeason> MealPlansInSeason { get; set; }
       public DbSet<Reservation> Reservations { get; set; }
       public DbSet<RoomType> RoomTypes { get; set; }
       public DbSet<SeasonType> SeasonTypes { get; set; }
        


    }

}
