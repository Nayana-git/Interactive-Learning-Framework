using InteractiveLearningFramework.Data;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Views.Components
{
    public class CourseViewComponent : ViewComponent
    {
        private const string ViewIndex = "Index";

        private readonly ApplicationDbContext _context;

        public CourseViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.Course.ToListAsync();
            return View(ViewIndex, items);
        }

    }
}
