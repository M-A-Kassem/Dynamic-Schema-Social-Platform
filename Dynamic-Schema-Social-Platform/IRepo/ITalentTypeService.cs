using Dynamic_Schema_Social_Platform.Enteties;

namespace Dynamic_Schema_Social_Platform.IRepo
{
    public interface ITalentTypeService
    {

        Task<TalentType> AddTalentTypeAsync(string talentName);

        Task<IEnumerable<TalentType>> GetAllTalentTypesAsync();

        Task<TalentType?> GetTalentTypeByIdAsync(int talentTypeId);

        Task<bool> DeleteTalentTypeAsync(int talentTypeId);
    }
}
