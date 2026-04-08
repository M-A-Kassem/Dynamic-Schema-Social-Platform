using Dynamic_Schema_Social_Platform.DtosRequest.TalentAttribute;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Schema_Social_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentAttributeController : ControllerBase
    {
        private readonly ITalentAttributeService _talentAttributeService;

        public TalentAttributeController(
            ITalentAttributeService talentAttributeService)
        {
            _talentAttributeService = talentAttributeService;
        }

        // POST: TalentAttribute
        [HttpPost]
        public async Task<IActionResult> AddAttribute([FromBody] AddTalentAttributeDto dto)
        {
            try
            {
                var attribute = await _talentAttributeService
                    .AddAttributeAsync(
                        dto.TalentTypeId,
                        dto.AttributeName,
                        dto.AttributeType
                    );

                var response = new TalentAttributeResponseDto
                {
                    AttributeId = attribute.AttributeId,
                    TalentTypeId = attribute.TalentTypeId,
                    AttributeName = attribute.AttributeName,
                    AttributeType = attribute.AttributeType
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TalentAttribute/talentType by id
        [HttpGet("talentType/{talentTypeId}")]
        public async Task<IActionResult> GetAttributesByTalentType(
            int talentTypeId)
        {
            var attributes = await _talentAttributeService
                .GetAttributesByTalentTypeAsync(talentTypeId);

            var response = attributes.Select(a => new TalentAttributeResponseDto
            {
                AttributeId = a.AttributeId,
                TalentTypeId = a.TalentTypeId,
                AttributeName = a.AttributeName,
                AttributeType = a.AttributeType
            });

            return Ok(response);
        }

        // DELETE: TalentAttribute by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            var result = await _talentAttributeService
                .DeleteAttributeAsync(id);

            if (!result)
                return NotFound("Attribute Not Found");

            return Ok("Attribute Deleted Successfully");
        }
    }
}
