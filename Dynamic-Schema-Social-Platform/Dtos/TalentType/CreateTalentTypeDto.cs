using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.Dtos.TalentType
{
    public class CreateTalentTypeDto
    {
        [Required]
        public string TalentName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]  
        public List<CreateAttributeDto> Attributes { get; set; } = new List<CreateAttributeDto>();
    }
}
