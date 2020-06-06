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
    [Authorize(Roles = "SuperAdmins")]
    public class UserController : Controller
    {
        private readonly RoleManager<UserRole> _role;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public UserController(
          UserManager<User> userManager,
          SignInManager<User> signInManager,
          RoleManager<UserRole> role)
        {
            _role = role;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_userManager.Users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public async Task<IActionResult> Create()
        {
            UserCreatetVm model = new UserCreatetVm();
            model.ApplicationRoles = await _role.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToListAsync();

            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreatetVm model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    City = model.City,
                    State = model.State,
                    Status = ContactStatus.Submitted,
                    Address = model.Address,
                    Zip = model.Zip
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserRole applicationRole = await _role.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {


            UserEditVm model = new UserEditVm();
            model.ApplicationRoles = _role.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Id = user.Id;
                    model.Name = user.Name;
                    model.PhoneNumber = user.PhoneNumber;
                    model.Address = user.Address;
                    model.City = user.City;
                    model.Zip = user.Zip;
                    model.State = user.State;
                    model.Email = user.Email;
                    model.ApplicationRoleId = _role.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id;
                }
            }

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserEditVm model)
        {
            return View();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UserEditVm model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Name = model.Name;

                    user.PhoneNumber = model.PhoneNumber;
                    user.City = model.City;
                    user.State = model.State;
                    user.Address = model.Address;
                    user.Zip = model.Zip;

                    string existingRole = _userManager.GetRolesAsync(user).Result.Single();
                    string existingRoleId = _role.Roles.Single(r => r.Name == existingRole).Id;
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (existingRoleId != model.ApplicationRoleId)
                        {
                            IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);
                            if (roleResult.Succeeded)
                            {
                                UserRole applicationRole = await _role.FindByIdAsync(model.ApplicationRoleId);
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                    if (newRoleResult.Succeeded)
                                    {
                                        return RedirectToAction("Index");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}