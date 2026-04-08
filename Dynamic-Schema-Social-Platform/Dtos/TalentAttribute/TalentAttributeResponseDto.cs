namespace Dynamic_Schema_Social_Platform.DtosRequest.TalentAttribute
{
    public class TalentAttributeResponseDto
    {
        public int AttributeId { get; set; }
        public int TalentTypeId { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public string AttributeType { get; set; } = string.Empty;
    }
}
