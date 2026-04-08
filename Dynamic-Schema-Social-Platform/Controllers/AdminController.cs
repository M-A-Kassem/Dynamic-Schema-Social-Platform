using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.Dtos.users;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Schema_Social_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // POST: Admin/talent
        [HttpPost("talent")]
        public async Task<IActionResult> CreateTalentType(
            [FromBody] CreateTalentTypeDto dto)
        {
            try
            {
                var result = await _adminService
                    .CreateTalentTypeWithAttributesAsync(dto);

                return Ok(new
                {
                    Message = "Talent Type Created Successfully",
                    TalentTypeId = result.TalentTypeId,
                    TalentName = result.TalentName,
                    Attributes = result.TalentAttributes.Select(a => new
                    {
                        a.AttributeId,
                        a.AttributeName,
                        a.AttributeType
                    })
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Admin/user
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserDto dto)
        {
            try
            {
                var user = await _adminService.CreateUserAsync(dto);

                return Ok(new
                {
                    Message = "User Created Successfully",
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Admin/users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();

            return Ok(users.Select(u => new
            {
                UserId = u.Id,
                u.UserName,
                u.Email,
                u.CreatedAt
            }));
        }

        // DELETE: Admin/talent/1
        [HttpDelete("talent/{id}")]
        public async Task<IActionResult> DeleteTalentType(int id)
        {
            var result = await _adminService.DeleteTalentTypeAsync(id);

            if (!result)
                return NotFound("Talent Type Not Found");

            return Ok("Talent Type Deleted Successfully");
        }
    }
}
