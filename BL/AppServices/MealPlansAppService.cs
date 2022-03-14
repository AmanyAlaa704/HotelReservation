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
    public class MealPlansAppService : AppServiceBase
    {

        public MealPlansAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<MealPlanDto> GetAllMealPlans()
        {
            return Mapper.Map<List<MealPlanDto>>(TheUnitOfWork.mealPlans.GetAllMealPlanss());
        }
        public MealPlanDto GetMealPlanById(int ID)
        {
            return Mapper.Map<MealPlanDto>(TheUnitOfWork.mealPlans.GetMealPlansByID(ID));
        }
        public MealPlanDto GetMealPlanByName(string Name)
        {
            return Mapper.Map<MealPlanDto>(TheUnitOfWork.mealPlans.GetMealPlansByName(Name));
        }
        public bool SaveNewMealPlan(MealPlanDto mealPlanDto)
        {
            if (mealPlanDto == null)
                throw new ArgumentNullException();

            bool result = false;
            var mailPlanRepository = Mapper.Map<MealPlans>(mealPlanDto);
            if (TheUnitOfWork.mealPlans.InsertMealPlans(mailPlanRepository))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool CheckMealPlansExist(MealPlanDto mealPlanDto)
        {                       
            return TheUnitOfWork.mealPlans.CheckMealPlansExist(Mapper.Map<MealPlans>(mealPlanDto));
        }
        public bool UpdateMealPlan(MealPlanDto mealPlanDto)
        {
            var mealPlans = Mapper.Map<MealPlans>(mealPlanDto);
            TheUnitOfWork.mealPlans.Update(mealPlans);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteMealPlan(int id)
        {
            bool result = false;
            TheUnitOfWork.mealPlans.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }




    }
}