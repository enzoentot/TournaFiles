namespace TournaManagementServices
{
    public class UserValidationServices
    {

        UserGetServices getservices = new UserGetServices();

        public bool CheckIfIGNExists(string ign)
        {
            bool result = getservices.GetUsers(ign) != null;
            return result;
        }

        public bool CheckIfUserExists(string ign, string mlbbid, string status)
        {
            bool result = getservices.GetUsers(ign, mlbbid, status) != null;
            return result;
        }

    }
}
