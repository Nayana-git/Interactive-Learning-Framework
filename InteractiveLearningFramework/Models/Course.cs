using InteractiveLearningFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Models
{
    public class Course
    {
        public Course()
        {
            Modules = new HashSet<Module>();
        }
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
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public CourseStatus Status { get; set; }
        public string Tag { get; set; }

        [Display(Name = "Course Image")]
        public string Image { get; set; } //Image, course image 
        public string Syllabus { get; set; } //File
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        [Required]
        [Display(Name = "Number Of Module")]
        public string NumberOfModule { get; set; }
        public ICollection<CourseInstructor> Instructors { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Announcement> Announcement { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    }

    
}
