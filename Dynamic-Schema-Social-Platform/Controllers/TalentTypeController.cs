using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.DtosRequest.TalentAttribute;
using Dynamic_Schema_Social_Platform.DtosRequest.TalentType;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Schema_Social_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentTypeController : ControllerBase
    {
        private readonly ITalentTypeService _talentTypeService;

        public TalentTypeController(ITalentTypeService talentTypeService)
        {
            _talentTypeService = talentTypeService;
        }

        // POST: TalentType
        [HttpPost]
        public async Task<IActionResult> AddTalentType(
            [FromBody] AddTalentTypeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var talentType = await _talentTypeService
                .AddTalentTypeAsync(dto.TalentName);

            var response = new TalentTypeResponseDto
            {
                TalentTypeId = talentType.TalentTypeId,
                TalentName = talentType.TalentName
            };

            return Ok(response);
        }

        // GET: TalentType
        [HttpGet]
        public async Task<IActionResult> GetAllTalentTypes()
        {
            var talentTypes = await _talentTypeService
                .GetAllTalentTypesAsync();

            var response = talentTypes.Select(t => new TalentTypeResponseDto
            {
                TalentTypeId = t.TalentTypeId,
                TalentName = t.TalentName,
                Attributes = t.TalentAttributes.Select(a =>
                    new TalentAttributeResponseDto
                    {
                        AttributeId = a.AttributeId,
                        TalentTypeId = a.TalentTypeId,
                        AttributeName = a.AttributeName,
                        AttributeType = a.AttributeType
                    }).ToList()
            });

            return Ok(response);
        }

        // GET: TalentType By Id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTalentTypeById(int id)
        {
            var talentType = await _talentTypeService
                .GetTalentTypeByIdAsync(id);

            if (talentType == null)
                return NotFound("Talent Type Not Found");

            var response = new TalentTypeResponseDto
            {
                TalentTypeId = talentType.TalentTypeId,
                TalentName = talentType.TalentName,
                Attributes = talentType.TalentAttributes.Select(a =>
                    new TalentAttributeResponseDto
                    {
                        AttributeId = a.AttributeId,
                        TalentTypeId = a.TalentTypeId,
                        AttributeName = a.AttributeName,
                        AttributeType = a.AttributeType
                    }).ToList()
            };

            return Ok(response);
        }

        // DELETE: TalentType By Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalentType(int id)
        {
            var result = await _talentTypeService
                .DeleteTalentTypeAsync(id);

            if (!result)
                return NotFound("Talent Type Not Found");

            return Ok("Talent Type Deleted Successfully");
        }
    }
}
