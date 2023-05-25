using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Town.DataContext;
using Town.Models;
using Town.ViewsModel;

namespace Town.Controllers
{
    public class HomeController : Controller
    {
        private readonly TownDbContext _townDbContext;

        public HomeController(TownDbContext townDbContext)
        {
            _townDbContext = townDbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<Infotmation>infotmations= new List<Infotmation>();
            HomeVM homeVM = new HomeVM()
            {
                Infotmations = infotmations,
            };
            return View(homeVM);
        }
    }
}