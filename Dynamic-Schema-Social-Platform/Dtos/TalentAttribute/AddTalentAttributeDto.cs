using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.DtosRequest.TalentAttribute
{
    public class AddTalentAttributeDto
    {
        [Required]
        public int TalentTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string AttributeType { get; set; } = "text";
    }
}
