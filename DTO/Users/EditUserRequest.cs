namespace ITQ2_BSIT32E1_Batoy_Nicholo.DTO.Users
{
    public class EditUserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
