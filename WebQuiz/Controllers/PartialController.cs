using System.Web.Mvc;

namespace WebQuiz.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Main()
        {
            return View();
        }

     
        // GET: Partial
        public ActionResult Weather()
        {
            return View();
        }

    }
}