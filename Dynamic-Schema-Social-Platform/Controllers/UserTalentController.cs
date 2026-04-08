using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.DtosRequest.UserTalent;
using Dynamic_Schema_Social_Platform.DtosRequest.UserTalentData;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dynamic_Schema_Social_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTalentController : ControllerBase
    {
        private readonly IUserTalentService _userTalentService;

        public UserTalentController(IUserTalentService userTalentService)
        {
            _userTalentService = userTalentService;
        }

        private int GetUserId()
        {
            return int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );
        }

        // GET: UserTalent/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableTalents()
        {
            var talents = await _userTalentService
                .GetAvailableTalentsAsync();

            return Ok(talents);
        }

        // POST: UserTalent/join
        [HttpPost("join")]
        public async Task<IActionResult> JoinTalent(
            [FromBody] JoinTalentDto dto)
        {
            try
            {
                var userId = GetUserId();

                var result = await _userTalentService
                    .JoinTalentAsync(userId, dto);

                return Ok(new
                {
                    Message = "Joined Successfully",
                    Talent = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("my-talents")]
        public async Task<IActionResult> GetMyTalents()
        {
            var userId = GetUserId();

            var result = await _userTalentService
                .GetMyTalentsAsync(userId);

            return Ok(result);
        }
    }
}
