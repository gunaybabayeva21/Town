using Microsoft.AspNetCore.Mvc;

namespace Town.Areas.Admin.Controllers
{
    public class DashboardController:Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
