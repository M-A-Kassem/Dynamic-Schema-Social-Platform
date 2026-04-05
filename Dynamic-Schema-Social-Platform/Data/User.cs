using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Schema_Social_Platform.Enteties
{
    public class User : IdentityUser<int>
    {

        [MaxLength(255)]
        public string? ProfilePic { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Nav Prop
        public ICollection<UserTalent> UserTalents { get; set; }
            = new List<UserTalent>();

        public ICollection<UserTalentData> UserTalentData { get; set; }
            = new List<UserTalentData>();

    }
}
