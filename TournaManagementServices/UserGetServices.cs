using TournaManagementData;
using TournaManagementModels;

namespace TournaManagementServices
{
    public class UserGetServices
    {
        public List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();

        }

        public List<User> GetUsers(string ign)
        {
            List<User> users = new List<User>();

            foreach (var user in GetAllUsers())
            {
                if (user.status == ign)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        public User GetUsers(string ign, string mlbbid, string status)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.ign == ign && user.mlbbid == mlbbid && user.status == status)

                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }
}