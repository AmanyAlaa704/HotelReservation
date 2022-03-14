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
    public class RoomTypeController : ControllerBase
    { 

        RoomTypeAppService _roomTypeAppService;

        public RoomTypeController(RoomTypeAppService roomTypeAppService)
    {
        this._roomTypeAppService = roomTypeAppService;
    }

    [HttpGet]
    public IActionResult GetAllRoomTypes()
    {
        return Ok(_roomTypeAppService.GetAllRoomTypes());
    }

    [HttpGet("{id}")]
    public IActionResult GetRoomTypeById(int ID)
    {
        return Ok(_roomTypeAppService.GetRoomTypesById(ID));
    }
    
    [HttpPost]
    public IActionResult CreateNewRoomType(RoomTypesDto mealPlanDto)
    {

        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        try
        {
            if (!_roomTypeAppService.CheckRoomTypesExist(mealPlanDto))
            {
                _roomTypeAppService.SaveNewRoomTypes(mealPlanDto);
                return Ok(new Response { Status = "Success", Message = "RoomType Created Sucessfully" });
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
    public IActionResult UpdateRoomType(int id, RoomTypesDto roomTypesDto)
    {

        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _roomTypeAppService.UpdateRoomTypes(roomTypesDto);
            return Ok(roomTypesDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoomType(int id)
    {
        try
        {
            _roomTypeAppService.DeleteRoomTypes(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
}