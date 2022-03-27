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
    public class SeansonController : ControllerBase
    {
        SeasonTypeAppService _seasonTypeAppService;
        MealPlansInSeasonAppService _mealPlansInSeasonAppService;
        



        public SeansonController(SeasonTypeAppService seasonTypeAppService
        ,MealPlansInSeasonAppService mealPlansInSeasonAppService)
        {
            this._seasonTypeAppService = seasonTypeAppService;
            this._mealPlansInSeasonAppService = mealPlansInSeasonAppService;

        }

        [HttpGet]
        public IActionResult GetAllSeasonTypes()
        {
            return Ok(_seasonTypeAppService.GetAllSeasonTypes());
        }


         [HttpGet("UnAssignedSeasonTypes/{MealPlanId}")]
        public IActionResult GetAllUnAssignedSeasonTypes(int MealPlanId)
        {            
            return Ok(_seasonTypeAppService.GetAllUnAssignedSeasonTypes(_mealPlansInSeasonAppService.GetAllMealPlansInSeasonByMealID(MealPlanId)));
        }

        [HttpGet("{ID}")]
        public IActionResult GetSeasonTypeById(int ID)
        {
            return Ok(_seasonTypeAppService.GetSeasonTypesById(ID));
        }
        [HttpGet("GetSeasonTypeByName/{name}")]
        public IActionResult GetSeasonTypeByName(string name)
        {
            return Ok(_seasonTypeAppService.GetSeasonTypesByName(name));
        }

        [HttpPost]
        public IActionResult CreateNewSeasonType(SeasonTypeDto mealPlanDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!_seasonTypeAppService.CheckSeasonTypesExist(mealPlanDto) && mealPlanDto.SeasionBegin < mealPlanDto.SeasionEnd)
                {
                    _seasonTypeAppService.SaveNewSeasonTypes(mealPlanDto);
                    return Ok(new Response { Status = "Success", Message = "SeasonType Created Sucessfully" });
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
        public IActionResult UpdateSeasonType(int id, SeasonTypeDto seasonTypeDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _seasonTypeAppService.UpdateSeasonTypes(seasonTypeDto);
                return Ok(seasonTypeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeasonType(int id)
        {
            try
            {
                _seasonTypeAppService.DeleteSeasonTypes(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}