using Microsoft.AspNetCore.Http;
using BL.AppServices;
using BL.Dtos;
using HotelReservation.HelpClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansInSeasonController : ControllerBase
    {
        MealPlansInSeasonAppService _mealPlansInSeason;
        
        public MealPlansInSeasonController(MealPlansInSeasonAppService mealPlansInSeason)
        {
            this._mealPlansInSeason = mealPlansInSeason;
        }

        [HttpGet]
        public IActionResult GetAllMealPlansInSeason()
        {
            return Ok(_mealPlansInSeason.GetAllMealPlansInSeason());
        }


        [HttpGet("{ID}")]

        public IActionResult GetMealPlansInSeasonByID(int ID)
        {
            return Ok(_mealPlansInSeason.GetMealPlansInSeasonByID(ID));
        }

        [HttpGet("GetAllMealPlansInSeasonByMealID/{MealID}")]

        public IActionResult GetAllMealPlansInSeasonByMealID(int MealID)
        {
            return Ok(_mealPlansInSeason.GetAllMealPlansInSeasonByMealID(MealID));
        }

        [HttpGet("GetAllMealPlansInSeasonBySeasonID/{SeasonID}")]

        public IActionResult GetAllMealPlansInSeasonBySeasonID(int SeasonID)
        {
            return Ok(_mealPlansInSeason.GetAllMealPlansInSeasonBySeasonID(SeasonID));
        }       

        [HttpPost]
        public IActionResult SaveNewMealPlansInSeason(MealPlansInSeasonDto mealPlansInSeasonDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!_mealPlansInSeason.CheckMealPlansInSeasonExist(mealPlansInSeasonDto))
                {
                    _mealPlansInSeason.SaveNewMealPlansInSeason(mealPlansInSeasonDto);
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
        public IActionResult UpdateMealPlansInSeason(int id, MealPlansInSeasonDto mealPlansInSeasonDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _mealPlansInSeason.UpdateMealPlansInSeason(mealPlansInSeasonDto);
                return Ok(mealPlansInSeasonDto);
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
                _mealPlansInSeason.DeleteMealPlansInSeason(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}