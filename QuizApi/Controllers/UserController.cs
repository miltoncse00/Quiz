using QuizApi.Model;
using QuizApi.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApi.Controllers
{
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        public readonly IRepository<UserModel> _userModel;
        public  int counter = 0;
        public UserController()
        {
            _userModel = new RepositoryT<UserModel>();
            for (int i = 0; i < 20; i++)
            {
                counter++;
                _userModel.Insert(new UserModel { Id = counter, Email = "test" + counter + "@test.com", Name = "test" + counter + " first Name", LastName = "test" + counter + "lastName", DateOfBirth = new System.DateTime(1990, counter % 12 + 1, 1), MonthlySalary = (40000)*(counter%3+1)});

            }
            // _userModel.Insert(new UserModel { Id = counter, Email = "test2@test.com", Name = "test2 first Name", LastName = "test2lastName", DateOfBirth = new System.DateTime(1990, 2, 2), MonthlySalary = 42000 });
        }
        [Route("all")]
        public HttpResponseMessage GetAllUsers()
        {
           
            return Request.CreateResponse(HttpStatusCode.OK, _userModel.Get(null));
        }
    }
}
