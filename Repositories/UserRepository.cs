using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public static class UserRepository
    {
        private static List<User> Users { get; } = new List<User>();
        private static int nextId = 1;

        public static List<User> GetAll() => Users;

        public static User? Get(int id) => Users.FirstOrDefault(u => u.Id == id);

        public static void Add(User user)
        {
            user.Id = nextId++;
            Users.Add(user);
        }

        public static void Update(User user)
        {
            var index = Users.FindIndex(u => u.Id == user.Id);
            if (index == -1) return;

            Users[index] = user;
        }

        public static void Delete(int id)
        {
            var user = Get(id);
            if (user is null) return;

            Users.Remove(user);
        }
    }
}
