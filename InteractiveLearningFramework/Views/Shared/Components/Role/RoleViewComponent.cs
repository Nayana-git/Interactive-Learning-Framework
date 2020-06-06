using InteractiveLearningFramework.Data;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Views.Components
{
    public class RoleViewComponent : ViewComponent
    {
        private const string ViewIndex = "Index";

        private readonly ApplicationDbContext _context;
        private RoleManager<UserRole> _roleManager;

        public RoleViewComponent(ApplicationDbContext context, RoleManager<UserRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _roleManager.Roles.ToListAsync();

            return View(ViewIndex, items);
        }

    }
}
