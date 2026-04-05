using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Schema_Social_Platform.Enteties
{
    public class TalentType
    {
        [Key]
        public int TalentTypeId { get; set; }

        [Required]
        public string TalentName { get; set; } = string.Empty;

        // Nav Prop
        public ICollection<UserTalent> UserTalents { get; set; } = new List<UserTalent>();

        public ICollection<TalentAttribute> TalentAttributes { get; set; } = new List<TalentAttribute>();
    }
}
