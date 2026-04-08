using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.DtosRequest.UserTalent
{
    public class AddUserTalentDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TalentTypeId { get; set; }
    }
}
