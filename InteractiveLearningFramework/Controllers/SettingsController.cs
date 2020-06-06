using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveLearningFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveLearningFramework.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index(SettingsTab tab)
        {
            if (tab == null)
            {
                tab = new SettingsTab
                {
                    ActiveTab = Tab.Users
                };
            }

            return View(tab);
        }

        public IActionResult SwitchToTabs(string tabname)
        {
            var tab = new SettingsTab();

            switch (tabname)
            {
                case "Users":
                    tab.ActiveTab = Tab.Users;
                    break;
                case "Roles":
                    tab.ActiveTab = Tab.Roles;
                    break;
                case "Courses":
                    tab.ActiveTab = Tab.Courses;
                    break;
                default:
                    tab.ActiveTab = Tab.Courses;
                    break;
            }

            return RedirectToAction(nameof(SettingsController.Index), tab);
        }
    }
}