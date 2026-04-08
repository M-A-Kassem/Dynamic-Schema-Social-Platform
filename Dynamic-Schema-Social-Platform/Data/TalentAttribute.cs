using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Schema_Social_Platform.Enteties
{
    public class TalentAttribute
    {
        [Key]
        public int AttributeId { get; set; }

        [ForeignKey("TalentType")]
        public int TalentTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string AttributeType { get; set; } = "text";

        // Nav Prop
        public TalentType TalentType { get; set; } = null!;

        public ICollection<UserTalentData> UserTalentData { get; set; }  = new List<UserTalentData>();
    }
}

