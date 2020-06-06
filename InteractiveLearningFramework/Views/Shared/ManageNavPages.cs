using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace InteractiveLearningFramework.Views.Manage
{
    public static class ManageNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";
        public static string Home => "Home";
        public static string Leaderboard => "Leaderboard";

        public static string Dashboard => "Dashboard";
        public static string Role => "Role";
        public static string User => "User";
        public static string Course => "Course";
        public static string Quiz => "Quiz";

        public static string ChangePassword => "ChangePassword";

        public static string ExternalLogins => "ExternalLogins";

        public static string Settings => "Settings";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        public static string SettingsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Settings);
        public static string HomeNavClass(ViewContext viewContext) => PageNavClass(viewContext, Home);
        public static string LeaderNavClass(ViewContext viewContext) => PageNavClass(viewContext, Leaderboard);
        public static string DashboardNavClass(ViewContext viewContext) => PageNavClass(viewContext, Dashboard);
        public static string RoleNavClass(ViewContext viewContext) => PageNavClass(viewContext, Role);
        public static string UserNavClass(ViewContext viewContext) => PageNavClass(viewContext, User);
        public static string CourseNavClass(ViewContext viewContext) => PageNavClass(viewContext, Course);
        public static string QuizNavClass(ViewContext viewContext) => PageNavClass(viewContext, Quiz);




        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
