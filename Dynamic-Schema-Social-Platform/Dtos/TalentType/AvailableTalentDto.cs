using Dynamic_Schema_Social_Platform.Dtos.Attributes;

namespace Dynamic_Schema_Social_Platform.Dtos.TalentType
{
    public class AvailableTalentDto
    {
        public int TalentTypeId { get; set; }
        public string TalentName { get; set; } = string.Empty;
        public List<AttributeInfoDto> Attributes { get; set; } = new List<AttributeInfoDto>();
    }
}
