using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MaklerSamxal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly MaklerSamxalDbContext db;
        public HomeController(MaklerSamxalDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(Testimionals testimionals)
        {
            var data = db.Testimionalss.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
        }
        public IActionResult Agents(Agent agents)
        {
            var data = db.Agents.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
            
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Sorgunuz qeyd alindi"
                });


            }

            return Json(new
            {
                error = true,
                message = "Sorgunuz qeyde alinmadi"
            });

        }


    }
}
