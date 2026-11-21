namespace ITQ2_BSIT32E1_Batoy_Nicholo.Data
{
    public class Usergroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new();
    }
}
