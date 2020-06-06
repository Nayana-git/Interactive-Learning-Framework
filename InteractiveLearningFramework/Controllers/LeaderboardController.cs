using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveLearningFramework.Models;
using InteractiveLearningFramework.Models.AccountViewModels;
using InteractiveLearningFramework.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace InteractiveLearningFramework.Controllers
{
    public class LeaderboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
