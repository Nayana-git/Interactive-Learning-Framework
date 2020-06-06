using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public ContactStatus Status { get; set; }

        public ICollection<CourseInstructor> Instructors { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
