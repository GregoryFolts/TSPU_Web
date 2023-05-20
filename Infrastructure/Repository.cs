using Laboratory_work_1.Models;

namespace Laboratory_work_1.Infrastructure
{
    public static class Repository
    {
        private static List<User> users = new List<User>();
        private static int maxId = 1;

        public static User[] GetData()
        {
            return users.ToArray();
        }

        public static User? GetData(int id) 
        {
            for (int i = 0; i < users.Count; i++) {
                if (users[i].Id == id)
                    return users[i];
            }
            return null;
        }

        public static void Add(User user) 
        {
            user.Id = maxId++;
            users.Add(user);
        }

        public static void Delete(int id) 
        {
            var user = GetData(id);
            if (user == null) 
            {
                return;
            }

            users.Remove(user);
        }

        public static void Edit(User userEditData)
        {
            var user = GetData(userEditData.Id);
            if (user == null)
            {
                return;
            }

            user.Name = userEditData.Name;
            user.Login = userEditData.Login;
        }
    }
}
