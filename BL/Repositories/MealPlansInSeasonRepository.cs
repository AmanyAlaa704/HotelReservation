using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class MealPlansInSeasonRepository : BaseRepository<MealPlansInSeason>
    {
        private DbContext HR_DbContext;

        public MealPlansInSeasonRepository(DbContext HR_DbContext) : base(HR_DbContext)
        {
            this.HR_DbContext = HR_DbContext;
        }


        public List<MealPlansInSeason> GetAllMealPlansInSeason()
        {
            return GetAll().ToList();
        }


        public List<MealPlansInSeason> GetAllMealPlansInSeasonByMealID(int mealID)
        {
            return GetWhere(MP => MP.MealPlanID == mealID).ToList();
        }
        public MealPlansInSeason GetMealPlansInSeasonByID(int ID)
        {
            return GetWhere(MP => MP.id == ID).FirstOrDefault();
        }
        public List<MealPlansInSeason> GetAllMealPlansInSeasonBySeasonID(int SeasonId)
        {
            return GetWhere(MP => MP.SeasonID == SeasonId).ToList();
        }

        public bool InsertMealPlans(MealPlansInSeason mealPlansInSeason)
        {
            if (!CheckMealPlansInSeasonExist(mealPlansInSeason))
            {
                return Insert(mealPlansInSeason);
            }
            else
                return false;
        }

        public void DeleteMealPlansInSeason(int id)
        {
            Delete(id);
        }


        public void UpdateMealPlansInSeason(MealPlansInSeason mealPlansInSeason)
        {
            Update(mealPlansInSeason);
        }


        public bool CheckMealPlansInSeasonExist(MealPlansInSeason mealPlansInSeason)
        {
            return GetAny(MP => MP.MealPlanID == mealPlansInSeason.MealPlanID && MP.SeasonID == mealPlansInSeason.SeasonID);
        }
    }
}