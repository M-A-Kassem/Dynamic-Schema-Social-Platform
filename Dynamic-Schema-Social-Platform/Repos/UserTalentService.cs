using Dynamic_Schema_Social_Platform.Data.DBContext;
using Dynamic_Schema_Social_Platform.Dtos.Attributes;
using Dynamic_Schema_Social_Platform.Dtos.TalentType;
using Dynamic_Schema_Social_Platform.DtosRequest.UserTalent;
using Dynamic_Schema_Social_Platform.DtosRequest.UserTalentData;
using Dynamic_Schema_Social_Platform.Enteties;
using Dynamic_Schema_Social_Platform.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform.Repos
{
    public class UserTalentService : IUserTalentService
    {
        private readonly AppDbContext _context;

        public UserTalentService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<AvailableTalentDto>>
            GetAvailableTalentsAsync()
        {
            return await _context.TalentTypes
                .Include(t => t.TalentAttributes)
                .Select(t => new AvailableTalentDto
                {
                    TalentTypeId = t.TalentTypeId,
                    TalentName = t.TalentName,
                    Attributes = t.TalentAttributes.Select(a =>
                        new AttributeInfoDto
                        {
                            AttributeId = a.AttributeId,
                            AttributeName = a.AttributeName,
                            AttributeType = a.AttributeType
                        }).ToList()
                }).ToListAsync();
        }

  
        public async Task<UserTalentResponseDto> JoinTalentAsync(
            int userId, JoinTalentDto dto)
        {

            var talentType = await _context.TalentTypes
                .Include(t => t.TalentAttributes)
                .FirstOrDefaultAsync(t => t.TalentTypeId == dto.TalentTypeId);

            if (talentType == null)
                throw new Exception("Talent Type Not Found");

 
            var alreadyJoined = await _context.UserTalents
                .AnyAsync(ut =>
                    ut.UserId == userId &&
                    ut.TalentTypeId == dto.TalentTypeId);

            if (alreadyJoined)
                throw new Exception("You Already Joined This Talent");


            var userTalent = new UserTalent
            {
                UserId = userId,
                TalentTypeId = dto.TalentTypeId
            };

            await _context.UserTalents.AddAsync(userTalent);

 
            foreach (var valueDto in dto.Values)
            {

                var attribute = talentType.TalentAttributes
                    .FirstOrDefault(a =>
                        a.AttributeName.ToLower() ==
                        valueDto.AttributeName.ToLower());

                if (attribute == null)
                    throw new Exception(
                        $"Attribute '{valueDto.AttributeName}' Not Found");

                var userTalentData = new UserTalentData
                {
                    UserId = userId,
                    AttributeId = attribute.AttributeId,
                    Value = valueDto.Value
                };

                await _context.UserTalentData.AddAsync(userTalentData);
            }

   
            await _context.SaveChangesAsync();


            return new UserTalentResponseDto
            {
                TalentName = talentType.TalentName,
                Data = dto.Values.Select(v => new UserTalentDataResponseDto
                {
                    AttributeName = v.AttributeName,
                    Value = v.Value
                }).ToList()
            };
        }

 
        public async Task<IEnumerable<UserTalentResponseDto>>
            GetMyTalentsAsync(int userId)
        {
            var userTalents = await _context.UserTalents
                .Include(ut => ut.TalentType)
                .Where(ut => ut.UserId == userId)
                .ToListAsync();

            var result = new List<UserTalentResponseDto>();

            foreach (var ut in userTalents)
            {
                var data = await _context.UserTalentData
                    .Include(ud => ud.TalentAttribute)
                    .Where(ud =>
                        ud.UserId == userId &&
                        ud.TalentAttribute.TalentTypeId == ut.TalentTypeId)
                    .Select(ud => new UserTalentDataResponseDto  
            {
             AttributeName = ud.TalentAttribute.AttributeName,
                        Value = ud.Value
                    }).ToListAsync();

                result.Add(new UserTalentResponseDto
                {
                    TalentName = ut.TalentType.TalentName,
                    Data = data
                });
            }

            return result;
        }
    }
}
