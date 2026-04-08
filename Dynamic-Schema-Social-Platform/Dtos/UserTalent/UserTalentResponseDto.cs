using Dynamic_Schema_Social_Platform.DtosRequest.UserTalentData;

namespace Dynamic_Schema_Social_Platform.DtosRequest.UserTalent
{
    public class UserTalentResponseDto
    {
        public string TalentName { get; set; } = string.Empty;
        public List<UserTalentDataResponseDto> Data { get; set; }
            = new List<UserTalentDataResponseDto>();
    }
}
