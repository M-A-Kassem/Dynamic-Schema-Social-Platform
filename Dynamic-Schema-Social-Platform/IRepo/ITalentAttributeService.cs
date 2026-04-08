using Dynamic_Schema_Social_Platform.Enteties;

namespace Dynamic_Schema_Social_Platform.IRepo
{
    public interface ITalentAttributeService
    {
        Task<TalentAttribute> AddAttributeAsync(int talentTypeId, string attributeName, string attributeType);

        Task<IEnumerable<TalentAttribute>> GetAttributesByTalentTypeAsync(int talentTypeId);

        Task<bool> DeleteAttributeAsync(int attributeId);
    }
}
