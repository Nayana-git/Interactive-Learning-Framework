using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.ViewModels
{
    public class ModuleVm
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Short Description cannot be longer than 300 characters.")]
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public CourseStatus Status { get; set; }
        public string Tag { get; set; }

        [Display(Name = "Course Image")]
        public IFormFile CourseFile { get; set; } //Image, course image 
        public IFormFile Syllabus { get; set; } //File
        [Required]
        [Display(Name = "Number Of Module")]
        public string NumberOfModule { get; set; }
        public string StatusMessage { get; set; }



        public IFormFile SubModuleFile { get; set; }

        public IEnumerable<CourseModuleVm> ModuleVM { get; set; }

    }

    public class CourseModuleVm
    {
     
        public int ModuleId { get; set; }
        [Required]
        public string Title { get; set; }
      
        public IEnumerable<SubModuleListViewModel> SubModuleList { get; set; }
    }
    public class SubModuleListViewModel
    {

        public int SubModuleId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
    }

}
