using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.Dtos.TalentType
{
    public class AddTalentTypeDto
    {
        [Required]
        [MaxLength(50)]
        public string TalentName { get; set; } = string.Empty;
    }
}
