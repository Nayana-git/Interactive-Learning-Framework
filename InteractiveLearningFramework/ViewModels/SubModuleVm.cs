using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.ViewModels
{
    public class SubModuleVm
    {
        public int Id { get; set; }
        [Required]
       
        public int ModuleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile File { get; set; }

    }
    public class SubModuleEditVm : SubModuleVm
    {
        public string FileName { get; set; }

    }
}
