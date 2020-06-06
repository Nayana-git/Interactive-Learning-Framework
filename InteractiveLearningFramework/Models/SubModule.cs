using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.Models
{
    public class SubModule
    {
   
        public int Id { get; set; }
        [Required]
        public int ModuleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }

        public Module Module { get; set; }

    }
}
