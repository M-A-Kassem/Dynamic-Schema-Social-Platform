using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Schema_Social_Platform.Enteties
{
    public class UserTalentData
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("TalentAttribute")]
        public int AttributeId { get; set; }

        [MaxLength(255)]
        public string Value { get; set; } = string.Empty;

        // Nav Prop
        public User User { get; set; } = null!;
        public TalentAttribute TalentAttribute { get; set; } = null!;
    }
}
