using Dynamic_Schema_Social_Platform.Data.DBContext;
using Dynamic_Schema_Social_Platform.Enteties;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform.Repos
{
    public class TalentTypeService : ITalentTypeService
    {
        private readonly AppDbContext _context;

        public TalentTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TalentType> AddTalentTypeAsync(string talentName)
        {
            var talentType = new TalentType
            {
                TalentName = talentName
            };

            await _context.TalentTypes.AddAsync(talentType);
            await _context.SaveChangesAsync();

            return talentType;
        }

        public async Task<IEnumerable<TalentType>> GetAllTalentTypesAsync()
        {
            return await _context.TalentTypes
                .Include(t => t.TalentAttributes)
                .ToListAsync();
        }

        public async Task<TalentType?> GetTalentTypeByIdAsync(int talentTypeId)
        {
            return await _context.TalentTypes
                .Include(t => t.TalentAttributes)
                .FirstOrDefaultAsync(t => t.TalentTypeId == talentTypeId);
        }

        public async Task<bool> DeleteTalentTypeAsync(int talentTypeId)
        {
            var talentType = await _context.TalentTypes
                .FindAsync(talentTypeId);

            if (talentType == null) return false;

            _context.TalentTypes.Remove(talentType);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

