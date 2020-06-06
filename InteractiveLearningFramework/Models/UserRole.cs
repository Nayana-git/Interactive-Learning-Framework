using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Models
{
    public class UserRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
        public UserRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public UserRole(string roleName, string description, string ipAddress)
        {
            this.Name = roleName;
            this.Description = description;
            this.CreatedDate = DateTime.UtcNow;
            this.IPAddress = ipAddress;
        }

    }
}
