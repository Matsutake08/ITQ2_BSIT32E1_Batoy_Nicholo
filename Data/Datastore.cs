using ITQ2_BSIT32E1_Batoy_Nicholo.Data;

namespace ITQ2_BSIT32E1_Batoy_Nicholo.Models
{
    public static class Datastore
    {
        public static List<User> Users { get; } = new()
        {
            new User { Id = 1, Name = "Nicholo Batoy", Email = "nicholo@example.com" },
            new User { Id = 2, Name = "Maria Santos", Email = "maria.santos@example.com" },
            new User { Id = 3, Name = "Juan Dela Cruz", Email = "juan.delacruz@example.com" },
            new User { Id = 4, Name = "Angela Reyes", Email = "angela.reyes@example.com" },
            new User { Id = 5, Name = "Carlo Mendoza", Email = "carlo.mendoza@example.com" },
            new User { Id = 6, Name = "Sofia Garcia", Email = "sofia.garcia@example.com" },
            new User { Id = 7, Name = "Marco Villanueva", Email = "marco.villanueva@example.com" },
            new User { Id = 8, Name = "Bea Aquino", Email = "bea.aquino@example.com" },
            new User { Id = 9, Name = "Rafael Torres", Email = "rafael.torres@example.com" },
            new User { Id = 10, Name = "Camille Navarro", Email = "camille.navarro@example.com" }
        };

        public static List<Usergroup> Usergroups { get; } = new()
        {
            new Usergroup { Id = 1, Name = "Admins" },
            new Usergroup { Id = 2, Name = "Moderators" },
            new Usergroup { Id = 3, Name = "Developers" },
            new Usergroup { Id = 4, Name = "Designers" },
            new Usergroup { Id = 5, Name = "QA Testers" },
            new Usergroup { Id = 6, Name = "Support" },
            new Usergroup { Id = 7, Name = "Marketing" },
            new Usergroup { Id = 8, Name = "Sales" },
            new Usergroup { Id = 9, Name = "HR" },
            new Usergroup { Id = 10, Name = "Guests" }
        };

        public static int NextUserId = 11;
        public static int NextUserGroupId = 11;
    }
}
