namespace ITQ2_BSIT32E1_Batoy_Nicholo.Data
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User Create(string name, string email);
        User? Update(int id, string name, string email);
        bool Delete(int id);
    }
}
