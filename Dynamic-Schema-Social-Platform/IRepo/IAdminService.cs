using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.Dtos.users;
using Dynamic_Schema_Social_Platform.Enteties;

namespace Dynamic_Schema_Social_Platform.IRepo
{
    public interface IAdminService
    {

        Task<TalentType> CreateTalentTypeWithAttributesAsync(
            CreateTalentTypeDto dto);

        Task<User> CreateUserAsync(CreateUserDto dto);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<bool> DeleteTalentTypeAsync(int talentTypeId);
    }
}
