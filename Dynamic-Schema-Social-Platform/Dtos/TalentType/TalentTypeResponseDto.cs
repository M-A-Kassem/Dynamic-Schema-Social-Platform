using Dynamic_Schema_Social_Platform.DtosRequest.TalentAttribute;

namespace Dynamic_Schema_Social_Platform.DtosRequest.TalentType
{
    public class TalentTypeResponseDto
    {
        public int TalentTypeId { get; set; }
        public string TalentName { get; set; } = string.Empty;
        public List<TalentAttributeResponseDto> Attributes { get; set; }
            = new List<TalentAttributeResponseDto>();
    }
}
