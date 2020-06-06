using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractiveLearningFramework.Data;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Authorization;
using InteractiveLearningFramework.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using InteractiveLearningFramework.Extensions;
using Microsoft.AspNetCore.Identity;

namespace InteractiveLearningFramework.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ApplicationDbContext _context;

        private readonly RoleManager<UserRole> _role;
        private readonly UserManager<User> _userManager;

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public CoursesController(IHostingEnvironment environment,
            ApplicationDbContext context, UserManager<User> userManager, RoleManager<UserRole> role)
        {
            hostingEnvironment = environment;
            _context = context;
            _role = role;
            _userManager = userManager;

        }
        [TempData]
        public string StatusMessage { get; set; }

        // GET: Courses

        /* public List<User> GetRolesToUsers(string ddlRole)
         {
            // var context = new ApplicationDbContext();
             var users =
               _context.Users.Where(x => x.Role.Select(y => y.RoleId).Contains(ddlRole)).ToList();

             return users;
         }*/
        public async Task<IActionResult> Index()
        {


            var roleList = await _userManager.GetUsersInRoleAsync("Instructor");
            return View(await _context.Course.ToListAsync());
        }
        /*public async Task<IActionResult> Assign()
        {



            var roleList = await _userManager.GetUsersInRoleAsync("Instructor");

            return View(new { rolel = roleList });
        }*/
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);

            var model = new CourseEditVm()
            {
                Id = course.Id,
                Name = course.Name,
                ShortName = course.ShortName,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                ShortDescription = course.ShortDescription,
                Description = course.Description,
                Status = CourseStatus.Created,
                Tag = course.Tag,
                NumberOfModule = course.NumberOfModule,

            };

            if (course == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            var Courses = new CourseVm();
            ViewBag.NoOfModules = Enumerable.Range(1, 15).Select(e => new SelectListItem()
            {
                Text = e.ToString(),
                Value = e.ToString()
            }).ToArray();

            return View(Courses);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseVm model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course()
                {
                    Name = model.Name,
                    ShortName = model.ShortName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ShortDescription = model.ShortDescription,
                    Description = model.Description,
                    Status = CourseStatus.Created,
                    CreatedDate = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    Tag = model.Tag,
                    NumberOfModule = model.NumberOfModule
                };
                if (model.Image != null)
                {
                    course.Image = hostingEnvironment.UploadFileToFolder(model.Image);
                }


                _context.Add(course);

                int.TryParse(model.NumberOfModule, out int x);

                for (int i = 1; i <= x; i++)
                {
                    course.Modules.Add(new Module()
                    {
                        Title = $"Module {i}"
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.NoOfModules = Enumerable.Range(1, 15).Select(e => new SelectListItem()
            {
                Text = e.ToString(),
                Value = e.ToString()
            }).ToArray();

            var model = new CourseEditVm()
            {
                Id = course.Id,
                Name = course.Name,
                ShortName = course.ShortName,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                ShortDescription = course.ShortDescription,
                Description = course.Description,
                Status = CourseStatus.Created,
                Tag = course.Tag,
                NumberOfModule = course.NumberOfModule,
                ImageName = course.Image
            };
            return View(model);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseEditVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var course = new Course()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        ShortName = model.ShortName,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        ShortDescription = model.ShortDescription,
                        Description = model.Description,
                        Status = CourseStatus.Created,
                        CreatedDate = DateTime.Now,
                        LastUpdated = DateTime.Now,
                        Tag = model.Tag,
                        NumberOfModule = model.NumberOfModule
                    };
                    if (model.Image != null)
                    {
                        course.Image = hostingEnvironment.UploadFileToFolder(model.Image);
                    }
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }

        public async Task<ActionResult> CourseEnrollment(Course model)
        {
            var courseId = model.Id;
            var user = await GetCurrentUserAsync();

            var userId = user?.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            var inrole = await _userManager.IsInRoleAsync(user, "Student");


            var courseEnroll = await _context.CourseEnrollments
                .FirstOrDefaultAsync(m => m.Id == courseId && m.UserId == userId);
            if (courseEnroll != null)
            {
                StatusMessage = "You are already enrolled";
                return RedirectToAction("Details", new { id = model.Id });
            }

            if (!inrole)
            {
                StatusMessage = "You are not eligible to enroll in this course";
                return RedirectToAction("Details", new { id = model.Id });
            }
            var enrollment = new CourseEnrollment();

            enrollment.UserId = userId;
            enrollment.CourseId = model.Id;

            _context.CourseEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return View();



        }

        public ActionResult EditModule()
        {
            return View();
        }
    }
}
