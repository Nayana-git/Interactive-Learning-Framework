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
    public class SubModuleController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public SubModuleController(IHostingEnvironment environment,
            ApplicationDbContext context)
        {
            hostingEnvironment = environment;
            _context = context;


        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var course = await _context.Course.Include(m => m.Modules)

                .FirstOrDefaultAsync(m => m.Id == id);

            var ct = from cc in course.Modules
                    select new CourseModuleVm
                    {
                        SubModuleList = _context.SubModules
                        .Where(x => x.ModuleId == cc.Id)
                        .Select(x => new SubModuleListViewModel
                        {
                            Title = x.Title,
                            SubModuleId = x.Id
                        }).ToList()
                    };


            var model = new ModuleVm()
            {
                CourseId = course.Id,
                Name = course.Name,
                ShortName = course.ShortName,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                ShortDescription = course.ShortDescription,
                Description = course.Description,
                Status = CourseStatus.Created,
                Tag = course.Tag,
                NumberOfModule = course.NumberOfModule,
                ModuleVM = from c in course.Modules
                           select new CourseModuleVm
                           {
                               Title = c.Title,
                               ModuleId = c.Id,
                               SubModuleList = _context.SubModules
                               .Where(x => x.ModuleId == c.Id)
                               .Select(x => new SubModuleListViewModel
                               {
                                   Title = x.Title,
                                   Content = x.Content,
                                   SubModuleId = x.Id
                               }).ToList()
                           }
            };


            if (course == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Create(int id)
        {
            var subModule = new SubModuleVm();
            subModule.ModuleId = id;


            return View(subModule);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubModuleVm model )
        {
            if (ModelState.IsValid)
            {
                var SubModule = new SubModule()
                {
                   // CourseId= model.CourseId,
                    ModuleId = model.ModuleId,
                    Title = model.Title,
                    Content = model.Content,

                };
                if (model.File != null)
                {
                    SubModule.File = hostingEnvironment.UploadFileToFolder(model.File);
                }


                _context.Add(SubModule);



                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subModule = await _context.SubModules.FindAsync(id);
            if (subModule == null)
            {
                return NotFound();
            }


            var model = new SubModuleEditVm()
            {
                Id = subModule.Id,
                ModuleId = subModule.ModuleId,
                Title = subModule.Title,
                Content = subModule.Content,
                FileName = subModule.File,

            };
            return View(model);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubModuleEditVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var subModule = new SubModule()
                    {
                        Id = model.Id,
                        ModuleId = model.ModuleId,
                        Title = model.Title,
                        Content = model.Content,


                    };
                    if (model.File != null)
                    {
                        subModule.File = hostingEnvironment.UploadFileToFolder(model.File);
                    }
                    _context.Update(subModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubModuleExists(model.Id))
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
        private bool SubModuleExists(int id)
        {
            return _context.SubModules.Any(e => e.Id == id);
        }
    }
}