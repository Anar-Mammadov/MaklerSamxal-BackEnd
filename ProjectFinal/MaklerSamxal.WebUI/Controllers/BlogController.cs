using MaklerSamxal.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Controllers
{
    public class BlogController : Controller
    {
        readonly MaklerSamxalDbContext db;


        public BlogController(MaklerSamxalDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Blogs.Where(b => b.DeleteByUserId == null).ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.Blogs.FirstOrDefault(b => b.Id == id);
            return View(data);
        }
    }
}
