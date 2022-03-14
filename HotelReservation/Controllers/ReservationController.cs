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
    public class ReservationController : ControllerBase

    { 
        ReservationAppService _reservationAppService;

        public ReservationController(ReservationAppService reservationAppService)
    {
        this._reservationAppService = reservationAppService;
    }

    [HttpGet]
    public IActionResult GetAllReservations()
    {
        return Ok(_reservationAppService.GetAllReservation());
    }

    [HttpGet("GetReservationById/{UserID}")]
    public IActionResult GetReservationById(string UserID)
    {
        return Ok(_reservationAppService.GetReservationByUserId(UserID));
    }

    [HttpPost]
    public IActionResult CreateNewReservation(ReservationDto reservationDto)
    {

        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        try
        {
            if (!_reservationAppService.CheckReservationExist(reservationDto))
            {
                _reservationAppService.SaveNewReservation(reservationDto);
                return Ok(new Response { Status = "Success", Message = "Reservation Created Sucessfully" });
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
    public IActionResult UpdateReservation(int id, ReservationDto reservationDto)
    {

        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _reservationAppService.UpdateReservation(reservationDto);
            return Ok(reservationDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        try
        {
            _reservationAppService.DeleteReservation(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
}