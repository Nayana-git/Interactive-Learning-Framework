using Microsoft.AspNetCore.Http;
using System.Collections.Generic;



namespace InteractiveLearningFramework.Models
{
    public class Module
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Course Course { get; set; }

        public ICollection<SubModule> SubModules { get; set; }
    }
}