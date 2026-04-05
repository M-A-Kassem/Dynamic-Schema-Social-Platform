using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Schema_Social_Platform.Enteties
{
    public class UserTalent
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("TalentType")]
        public int TalentTypeId { get; set; }

        // Nav Prop
        public User User { get; set; } = null!;
        public TalentType TalentType { get; set; } = null!;
    }
}
