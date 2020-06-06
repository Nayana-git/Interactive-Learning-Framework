using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.ViewModels
{
    public class CourseVm
    {
        public int Id { get; set; }
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
        public IFormFile Image { get; set; } //Image, course image 
        public IFormFile Syllabus { get; set; } //File
        [Required]
        [Display(Name = "Number Of Module")]
        public string NumberOfModule { get; set; }
        public string StatusMessage { get; set; }
    }

    public enum CourseStatus
    {
        Approved,
        Rejected,
        Created
    }

    public class CourseEditVm : CourseVm
    {
        public string ImageName { get; set; }

    }
}
