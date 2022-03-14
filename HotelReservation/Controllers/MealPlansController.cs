using BL.AppServices;
using BL.Dtos;
using HotelReservation.HelpClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansController : ControllerBase
    {
        MealPlansAppService _mealPlansAppService;

        public MealPlansController(MealPlansAppService mealPlansAppService)
        {
            this._mealPlansAppService = mealPlansAppService;
        }

        [HttpGet]
        public IActionResult GetAllMealPlans()
        {
            return Ok(_mealPlansAppService.GetAllMealPlans());
        }

        [HttpGet("{id}")]

        public IActionResult GetMealPlanById(int ID)
        {
            return Ok(_mealPlansAppService.GetMealPlanById(ID));
        }
        [HttpGet("GetMealPlanByName/{name}")]
        public IActionResult GetMealPlanByName(string name)
        {
            return Ok(_mealPlansAppService.GetMealPlanByName(name));
        }

        [HttpPost]
        public IActionResult CreateNewMealPlan(MealPlanDto mealPlanDto)
        {            

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!_mealPlansAppService.CheckMealPlansExist(mealPlanDto))
                {
                    _mealPlansAppService.SaveNewMealPlan(mealPlanDto);
                    return Ok(new Response { Status = "Success", Message = "MealPlan Created Sucessfully" });
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMealPlan(int id, MealPlanDto mealPlanDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _mealPlansAppService.UpdateMealPlan(mealPlanDto);
                return Ok(mealPlanDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMealPlan(int id)
        {
            try
            {
                _mealPlansAppService.DeleteMealPlan(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}