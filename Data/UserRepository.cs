using ITQ2_BSIT32E1_Batoy_Nicholo.Models;

namespace ITQ2_BSIT32E1_Batoy_Nicholo.Data
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            return Datastore.Users;
        }

        public User? GetById(int id)
        {
            foreach (User user in Datastore.Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public User Create(string name, string email)
        {
            User newUser = new User
            {
                Id = Datastore.NextUserId++,
                Name = name,
                Email = email
            };

            Datastore.Users.Add(newUser);
            return newUser;
        }

        public User? Update(int id, string name, string email)
        {
            User? existingUser = GetById(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = name;
            existingUser.Email = email;
            return existingUser;
        }

        public bool Delete(int id)
        {
            User? existingUser = GetById(id);
            if (existingUser == null)
            {
                return false;
            }

            Datastore.Users.Remove(existingUser);
            return true;
        }
    }
}
