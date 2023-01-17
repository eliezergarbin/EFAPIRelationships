using Microsoft.AspNetCore.Mvc;

namespace EFAPIRelationships.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
