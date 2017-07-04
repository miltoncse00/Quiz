using System;
using System.Web.Http;

namespace QuizApi.Controllers
{
    public class BaseController : ApiController
    {
    
        public void ValidateApiVersionAndState()
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("ModelState is invalid");

        }

    }
}
