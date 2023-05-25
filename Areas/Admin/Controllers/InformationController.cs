using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Town.DataContext;
using Town.Models;
using Town.ViewsModel.InformationVM;

namespace Town.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InformationController:Controller
    {
        private readonly TownDbContext _townDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InformationController(TownDbContext townDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _townDbContext = townDbContext;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            List<Infotmation> infotmations = await _townDbContext.Infotmations.ToListAsync();
            return View(infotmations);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create( InfoCreateVM createVM)
        {
            if (ModelState.IsValid)
            {
                return View(createVM);
            }
            Infotmation infotmation = new Infotmation()
            {
                IconName = createVM.IconName,
                Title = createVM.Title,
                Description = createVM.Description,
            };
            
            _townDbContext.AddAsync(infotmation);
            _townDbContext.SaveChanges();
            return View(createVM);
          

        }

        public async Task<IActionResult> Edit(int id)
        {
            Infotmation infotmation = new Infotmation();
            if (infotmation == null)
            {
                return NotFound();
            }
            InfoEditVM cartEdit = new InfoEditVM()
            {
                Description= infotmation.Description,
                IconName= infotmation.IconName,
                Title= infotmation.Title,
            };
            return (View(cartEdit));
        }
         
        [HttpPost]

        public async Task<IActionResult> Edit (int id,InfoEditVM editVM)
        {
            if (!ModelState.IsValid) { return View(); }
            Infotmation infotmation = await _townDbContext.Infotmations.FindAsync(id);
            InfoEditVM infoEditVM = new InfoEditVM()
            {
                Description= editVM.Description,
               IconName= editVM.IconName,
               Title= editVM.Title,
            };
            editVM.Description = editVM.Description;
            editVM.Title = editVM.Title;
            editVM.IconName = editVM.IconName;

            await _townDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
