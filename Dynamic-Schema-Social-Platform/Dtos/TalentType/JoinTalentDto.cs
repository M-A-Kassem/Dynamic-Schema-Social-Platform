using Dynamic_Schema_Social_Platform.Dtos.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.Dtos.TalentType
{
    public class JoinTalentDto
    {
        [Required]
        public int TalentTypeId { get; set; }

        [Required]
        public List<AttributeValueDto> Values { get; set; } = new List<AttributeValueDto>();
    }
}
