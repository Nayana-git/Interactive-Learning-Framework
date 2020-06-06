using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.ViewModels
{
    public class SettingsTab
    {
        public Tab ActiveTab { get; set; }

    }

    public enum Tab
    {
        Users,
        Roles,
        Courses
    }
}
