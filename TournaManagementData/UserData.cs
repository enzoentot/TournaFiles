using System.Reflection.Metadata;
using TournaManagementModels;

namespace TournaManagementData
{
    public class UserData
    {
        List<User> users;
        SqlDbData sqlData;

        public UserData()
        {
            users = new List<User>();
            sqlData = new SqlDbData();
        }
        public List<User> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(User user)
        {
            return sqlData.AddUser(user.ign, user.mlbbid, user.status);
        }

        public int UpdateUser(User user)
        {
            return sqlData.UpdateUser(user.ign, user.mlbbid, user.status);
        }

        public int DeleteUser(User user)
        {
            return sqlData.DeleteUser(user.ign);
        }
    }
}
