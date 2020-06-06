using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveLearningFramework.Models;
using InteractiveLearningFramework.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveLearningFramework.Controllers
{
    // GET: Role
    [Authorize(Roles = "SuperAdmins")]
    public class RoleController : Controller
    {
        private RoleManager<UserRole> roleManager;
        private UserManager<User> userManager;

        public RoleController(RoleManager<UserRole> roleMgr, UserManager<User> userMgr)
        {
            roleManager = roleMgr;
            userManager = userMgr;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                string ipaddress = HttpContext.Connection?.RemoteIpAddress?.ToString();

                IdentityResult result = await roleManager.CreateAsync(new UserRole(model.Name, model.Description, ipaddress));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            List<User> members = new List<User>();
            List<User> nonMember = new List<User>();

            foreach (User user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name)
                    ? members
                    : nonMember;
                list.Add(user);
            }

            return View(new EditRoleVm
            {
                Role = role,
                Members = members,
                NonMembers = nonMember
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModifyRoleVm modifyRole)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                UserRole role = await roleManager.FindByIdAsync(modifyRole.RoleId);
                role.Name = modifyRole.RoleName;
                role.Description = modifyRole.Description;
                result = await roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    AddErrors(result);
                }

                foreach (string userId in modifyRole.IdsToAdd ?? new string[] { })
                {
                    User user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, modifyRole.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                }

                foreach (string userId in modifyRole.IdsToRemove ?? new string[] { })
                {
                    User user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, modifyRole.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(modifyRole.RoleId);
        }

        public async Task<IActionResult> Delete(string id)
        {
            UserRole role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }

            return View("Index", roleManager.Roles);
        }
    }
}