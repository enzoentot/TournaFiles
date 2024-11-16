using TournaManagementData;
using TournaManagementModels;

namespace TournaManagementServices
{
    public class UserTransactionServices
    {
        UserValidationServices validationServices = new UserValidationServices();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserExists(user.ign, user.mlbbid, user.status))
            {
                userData.AddUser(user);
            }

            return result;
        }

        public bool CreateUser(string ign, string mlbbid, string status)
        {
            User user = new User { ign = ign, mlbbid = mlbbid, status = status };

            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = validationServices.CheckIfIGNExists(user.ign);

            if (validationServices.CheckIfIGNExists(user.ign))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string ign, string mlbbid, string status)
        {
            User user = new User { ign = ign, mlbbid = mlbbid, status = status };

            return UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfIGNExists(user.ign))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
}
