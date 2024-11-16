using Microsoft.AspNetCore.Mvc;
using TournaManagementServices;
using TournaManagementModels;

namespace EnzoTournaAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class TournaManagementController : ControllerBase
    {
        UserGetServices userGetServices;
        UserTransactionServices userTransactionServices;

        public TournaManagementController()
        {
            userGetServices = new UserGetServices();
            userTransactionServices = new UserTransactionServices();
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var user = userGetServices.GetAllUsers();

            List<User> users = new List<User>();

            foreach (var Users in user)
            {
                users.Add(new EnzoTournaAPI.User { ign = Users.ign, mlbbid = Users.mlbbid, status = Users.status });
            }
            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = userTransactionServices.CreateUser(request.ign, request.mlbbid, request.status);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUSer(User request)
        {
            var result = userTransactionServices.UpdateUser(request.ign, request.mlbbid, request.status);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(User request)
        {
            var deleteuser = new TournaManagementModels.User
            {
                ign = request.ign
            };

            var result = userTransactionServices.DeleteUser(deleteuser);

            return new JsonResult(result);
        }


    }
}