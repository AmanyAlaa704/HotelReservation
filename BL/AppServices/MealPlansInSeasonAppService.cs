using AutoMapper;
using BL.Bases;
using BL.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class MealPlansInSeasonAppService : AppServiceBase
    {

        public MealPlansInSeasonAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<MealPlansInSeasonDto> GetAllMealPlansInSeason()
        {
            return Mapper.Map<List<MealPlansInSeasonDto>>(TheUnitOfWork.mealPlansinSeason.GetAllMealPlansInSeason());
        }
        public MealPlansInSeasonDto GetMealPlansInSeasonByID(int ID)
        {
            return Mapper.Map<MealPlansInSeasonDto>(TheUnitOfWork.mealPlansinSeason.GetMealPlansInSeasonByID(ID));
        }
        public List<MealPlansInSeasonDto> GetAllMealPlansInSeasonByMealID(int ID)
        {
            return Mapper.Map<List<MealPlansInSeasonDto>>(TheUnitOfWork.mealPlansinSeason.GetAllMealPlansInSeasonByMealID(ID));
        }

        public List<MealPlansInSeasonDto> GetAllMealPlansInSeasonBySeasonID(int ID)
        {
            return Mapper.Map<List<MealPlansInSeasonDto>>(TheUnitOfWork.mealPlansinSeason.GetAllMealPlansInSeasonBySeasonID(ID));
        }
        public bool SaveNewMealPlansInSeason(MealPlansInSeasonDto mealPlansInSeasonDto)
        {
            if (mealPlansInSeasonDto == null)
                throw new ArgumentNullException();

            bool result = false;
            var mailPlanInSeason = Mapper.Map<MealPlansInSeason>(mealPlansInSeasonDto);
            if (TheUnitOfWork.mealPlansinSeason.InsertMealPlans(mailPlanInSeason))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool CheckMealPlansInSeasonExist(MealPlansInSeasonDto mealPlansInSeasonDto)
        {
            return TheUnitOfWork.mealPlansinSeason.CheckMealPlansInSeasonExist(Mapper.Map<MealPlansInSeason>(mealPlansInSeasonDto));
        }
        public bool UpdateMealPlansInSeason(MealPlansInSeasonDto mealPlansInSeasonDto)
        {
            var mealPlansinSeason = Mapper.Map<MealPlansInSeason>(mealPlansInSeasonDto);
            TheUnitOfWork.mealPlansinSeason.UpdateMealPlansInSeason(mealPlansinSeason);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteMealPlansInSeason(int id)
        {
            bool result = false;
            TheUnitOfWork.mealPlansinSeason.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }




    }
}