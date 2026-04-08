using Dynamic_Schema_Social_Platform.Data.DBContext;
using Dynamic_Schema_Social_Platform.Enteties;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform.Repos
{
    public class TalentAttributeService : ITalentAttributeService
    {
        private readonly AppDbContext _context;

        public TalentAttributeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TalentAttribute> AddAttributeAsync(
            int talentTypeId,
            string attributeName,
            string attributeType)
        {
            var talentType = await _context.TalentTypes
                .FindAsync(talentTypeId);

            if (talentType == null)
                throw new Exception("Talent Type Not Found");

            var attribute = new TalentAttribute
            {
                TalentTypeId = talentTypeId,
                AttributeName = attributeName,
                AttributeType = attributeType
            };

            await _context.TalentAttributes.AddAsync(attribute);
            await _context.SaveChangesAsync();

            return attribute;
        }

        public async Task<IEnumerable<TalentAttribute>> GetAttributesByTalentTypeAsync(
            int talentTypeId)
        {
            return await _context.TalentAttributes
                .Where(a => a.TalentTypeId == talentTypeId)
                .ToListAsync();
        }

        public async Task<bool> DeleteAttributeAsync(int attributeId)
        {
            var attribute = await _context.TalentAttributes
                .FindAsync(attributeId);

            if (attribute == null) return false;

            _context.TalentAttributes.Remove(attribute);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
