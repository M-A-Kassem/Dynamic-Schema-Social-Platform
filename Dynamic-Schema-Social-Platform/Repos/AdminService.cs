using Dynamic_Schema_Social_Platform.Data.DBContext;
using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.Dtos.users;
using Dynamic_Schema_Social_Platform.Enteties;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform.Repos
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminService(
            AppDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<TalentType> CreateTalentTypeWithAttributesAsync(
            CreateTalentTypeDto dto)
        {

            if (dto.Attributes == null || dto.Attributes.Count == 0)
                throw new Exception("Must Add At Least One Attribute");

            // Create TalentType
            var talentType = new TalentType
            {
                TalentName = dto.TalentName
            };

            // Add Attributes
            foreach (var attr in dto.Attributes)
            {
                talentType.TalentAttributes.Add(new TalentAttribute
                {
                    AttributeName = attr.AttributeName,
                    AttributeType = attr.AttributeType
                });
            }

            await _context.TalentTypes.AddAsync(talentType);
            await _context.SaveChangesAsync();

            return talentType;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception(
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );

            await _userManager.AddToRoleAsync(user, "User");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
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
