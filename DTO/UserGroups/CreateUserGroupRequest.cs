using ITQ2_BSIT32E1_Batoy_Nicholo.Data;

namespace ITQ2_BSIT32E1_Batoy_Nicholo.DTO.UserGroups
{
    public class CreateUserGroupRequest
    {
        public string Name { get; set; } = string.Empty;
        public List<User> ListOfUsers { get; set; } = new();
    }
}
