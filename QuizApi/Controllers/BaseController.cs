using System;
using System.Web.Http;

namespace QuizApi.Controllers
{
    public class BaseController : ApiController
    {
    
        public void ValidateApiVersionAndState(int version)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("ModelState is invalid");

        }

    }
}
