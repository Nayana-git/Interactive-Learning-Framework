using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Authorization;
using InteractiveLearningFramework.Data;
using Microsoft.EntityFrameworkCore;
using InteractiveLearningFramework.ViewModels;

namespace InteractiveLearningFramework.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _Context;

        public HomeController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _Context.Course.ToListAsync();

            var model = from c in course
                        select new CourseEditVm
                        {
                            StartDate = c.StartDate,
                            ShortName = c.ShortName,
                            Name = c.Name,
                            ShortDescription = c.ShortDescription,
                            ImageName = c.Image,
                            Id = c.Id
                        };
            return View(model);
        }

        public async Task<IActionResult> Dashboard()
        {
            var course = await _Context.Course.ToListAsync();

            var model = from c in course
                        select new CourseEditVm
                        {
                           
                            Name = c.Name,
                            
                            Id = c.Id
                        };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
