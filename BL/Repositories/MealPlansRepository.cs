using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;



namespace BL.Repositories
{
    public class MealPlansRepository : BaseRepository<MealPlans>
    {
        private DbContext HR_DbContext;

        public MealPlansRepository(DbContext HR_DbContext) : base(HR_DbContext)
        {
            this.HR_DbContext = HR_DbContext;
        }


        public List<MealPlans> GetAllMealPlanss()
        {
            return GetAll().ToList();
        }


        //public MealPlans GetLastOrDefault()
        //{
        //    return LastOrDefault(e=>e.ID==e.ID);
        //}

        public MealPlans GetMealPlansByID(int ID)
        {
            return GetWhere(MP => MP.ID == ID).FirstOrDefault();
        }

        public MealPlans GetMealPlansByName(string Name)
        {
            return GetWhere(MP => MP.MealPlanName == Name).FirstOrDefault();
        }

        public bool InsertMealPlans(MealPlans mealPlans)
        {
            if (!CheckMealPlansExist(mealPlans.MealPlanName))
            {
                return Insert(mealPlans);
            }
            else
                return false;
        }

        public void DeleteMealPlans(int id)
        {
            Delete(id);
        }


        public void UpdateMealPlans(MealPlans mealPlans)
        {
            Update(mealPlans);
        }


        public bool CheckMealPlansExist(string mealPlansName)
        {
            return GetAny(MP => MP.MealPlanName == mealPlansName);
        }
    }
}