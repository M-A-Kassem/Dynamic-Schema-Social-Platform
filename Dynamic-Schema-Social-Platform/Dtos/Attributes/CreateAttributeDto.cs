using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.Dtos.Attributes
{
    public class CreateAttributeDto
    {
        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string AttributeType { get; set; } = "text";
    }
}
