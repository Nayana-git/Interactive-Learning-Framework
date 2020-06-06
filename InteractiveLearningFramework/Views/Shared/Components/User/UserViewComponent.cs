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
    public class UserViewComponent : ViewComponent
    {
        private const string ViewIndex = "Index";

        private readonly ApplicationDbContext _context;

        private UserManager<User> _userManager;


        public UserViewComponent(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _userManager.Users.ToListAsync();
            return View(ViewIndex, items);
        }

    }
}
