using System.ComponentModel.DataAnnotations;

namespace Dynamic_Schema_Social_Platform.DtosRequest.UserTalentData
{
    public class AddUserTalentDataDto
    {
        public string AttributeName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
