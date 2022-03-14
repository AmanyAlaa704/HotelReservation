using BL.Interfaces;
using BL.Repositories;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {

        private DbContext HR_DbContext { get; set; }
        private UserManager<ApplicationUsersIdentity> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountRepository Account;
        public AccountRepository account
        {
            get
            {
                if (Account == null)
                    Account = new AccountRepository(HR_DbContext, _userManager, _roleManager);
                return Account;
            }
        }

        public MealPlansRepository MealPlans;
        public MealPlansRepository mealPlans
        {
            get
            {
                if (MealPlans == null)                
                    MealPlans = new MealPlansRepository(HR_DbContext);

                    return MealPlans;
                
            }
        }
        public RoomTypeRepository RoomType;
        public RoomTypeRepository roomType
        {
            get
            {
                if (RoomType == null)
                    RoomType = new RoomTypeRepository(HR_DbContext);
                return RoomType;

            }
        }
        public SeasonTypeRepository SeasonType;

        public SeasonTypeRepository seasonType
        {
            get
            {
                if (SeasonType == null)
                    SeasonType = new SeasonTypeRepository(HR_DbContext);
                return SeasonType;
            }
        }

        public ReservationRepository Reservation;
        public ReservationRepository reservation
        {
            get
            {
                if (Reservation == null)
                    Reservation = new ReservationRepository(HR_DbContext);
                return Reservation;

            }
        }

        public UnitOfWork(ApplicationDBContext HR_DbContext, UserManager<ApplicationUsersIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.HR_DbContext = HR_DbContext;
        }

        public int Commit()
        {
            return HR_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            HR_DbContext.Dispose();
        }

       
    }
}
