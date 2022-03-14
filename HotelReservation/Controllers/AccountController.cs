using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BL.AppServices;
using BL.Dtos;
using HotelReservation.HelpClasses;
using System.Security.Claims;
using DAL;
using BL.StaticClasses;

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountAppService _accountAppService;        
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(
            AccountAppService accountAppService,            
            IHttpContextAccessor httpContextAccessor)
        {
            this._accountAppService = accountAppService;            
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _accountAppService.GetAllAccounts();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var res = _accountAppService.GetAccountById(id);
            return Ok(res);
        }

        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = _accountAppService.GetAccountById(userID);
            return Ok(res);
        }
      

        [HttpPost("/Register")]      
       public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_accountAppService.CheckAccountExistsByData(model))
            {
            var result = await _accountAppService.Register(model);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new Response { Status = "Error", Message = result.Errors.FirstOrDefault().Description });

            ApplicationUsersIdentity identityUser = await _accountAppService.Find(model.Email, model.PasswordHash);
            await _accountAppService.AssignToRole(identityUser.Id, UserRoles.Guest);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            else
            {
                return BadRequest();
            }
        }
      
        
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _accountAppService.Find(model.Email, model.PasswordHash);
            if (user != null )
            {
                dynamic token = await _accountAppService.CreateToken(user);
               
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
