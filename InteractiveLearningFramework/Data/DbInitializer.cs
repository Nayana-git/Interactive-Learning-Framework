using InteractiveLearningFramework.ViewModels;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InteractiveLearningFramework.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                var request = serviceProvider.GetRequiredService<IHttpContextAccessor>();


                var ipAddress = request.HttpContext?.Connection?.RemoteIpAddress?.ToString();



                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything
                var superAdminUser = new User
                {
                    UserName = "superadmin@ilf.com",
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "admin@ilf.com",
                    Status = ContactStatus.Approved
                };
                var adminID = await EnsureUser(serviceProvider, "Password@123", "admin@ilf.com", superAdminUser);
                await EnsureRole(serviceProvider, adminID, Constants.SuperAdmin, "Super Admin Role", ipAddress);

                var adminUser = new User
                {
                    UserName = "manager@ilf.com",
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "manager@ilf.com",
                    Status = ContactStatus.Approved
                };
                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, "Password@123", "manager@ilf.com", adminUser);
                await EnsureRole(serviceProvider, managerID, Constants.ManagerRole, "Manager Role", ipAddress);

                await EnsureSeedRole(serviceProvider, Constants.Student, "Student Role", ipAddress);
                await EnsureSeedRole(serviceProvider, Constants.Instructor, "Instructor Role", ipAddress);
            }
        }
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName, User user)
        {
            var userManager = serviceProvider.GetService<UserManager<User>>();

            try
            {
                var users = await userManager.FindByNameAsync(user.UserName);
                if (users == null)
                {
                    users = user;
                    await userManager.CreateAsync(users, testUserPw);
                }

                return users.Id;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private static async Task<IdentityResult> EnsureSeedRole(IServiceProvider serviceProvider, string role, string description, string ip)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<UserRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new UserRole(role, description, ip));
            }
            return IR;

        }
        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                  string uid, string role, string description, string ip)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<UserRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new UserRole(role, description, ip));
            }

            var userManager = serviceProvider.GetService<UserManager<User>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

    }
}
