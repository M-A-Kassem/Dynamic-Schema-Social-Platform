using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.Dtos.Attributes
{
    public class AttributeValueDto
    {
        [Required]
        public string AttributeName { get; set; } = string.Empty;

        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
