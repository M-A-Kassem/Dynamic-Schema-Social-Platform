using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.DtosRequest.UserTalent;
using Dynamic_Schema_Social_Platform.Enteties;

namespace Dynamic_Schema_Social_Platform.IRepo
{
    public interface IUserTalentService
    {
        Task<IEnumerable<AvailableTalentDto>> GetAvailableTalentsAsync();

        Task<UserTalentResponseDto> JoinTalentAsync(
            int userId, JoinTalentDto dto);

        Task<IEnumerable<UserTalentResponseDto>> GetMyTalentsAsync(
            int userId);
    }
}
