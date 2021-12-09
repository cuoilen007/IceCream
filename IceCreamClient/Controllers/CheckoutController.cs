using Microsoft.AspNetCore.Mvc;

namespace IceCreamClient.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
