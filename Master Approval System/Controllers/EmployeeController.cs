using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_Approval_System.Models;
using Master_Approval_System.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Master_Approval_System.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/addEmployee
        public ActionResult addEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEmployee(AddEmployeeViewModel employee)
        {

            DashboardMessageViewModel msg = new DashboardMessageViewModel();

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            ApplicationDbContext context = new ApplicationDbContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            user.UserName = employee.Email;
            user.Email = employee.Email;

            string userPWD = employee.Password;

            var chkUser = UserManager.Create(user, userPWD);


            msg.State = "Error";
            msg.Message = "Error during creation !!";
            
            if (chkUser.Succeeded)
            {
                if (employee.isApprover)
                {
                    UserManager.AddToRole(user.Id, "Approver");
                }
                else
                {
                    UserManager.AddToRole(user.Id, "Employee");
                }
                msg.State = "Normal";
                msg.Message = "Employee Created Successfully !!";
            }

            return RedirectToAction("redirectView", "Dashboard", new { Message = msg.Message, Status = msg.State });

        }

        public async System.Threading.Tasks.Task<ActionResult> AddApprovalProcess()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            List<ApplicationUser> users = new List<ApplicationUser>();
            var role = await RoleManager.FindByIdAsync("3a6e2158-8b77-4ff8-9c15-66a48e00248e");
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }
            ApprovalProcessViewModel model = new ApprovalProcessViewModel
            {
                ApproverList = users
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddApprovalProcess(ApprovalProcessViewModel approvers)
        {
            if (!ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                List<ApplicationUser> users = new List<ApplicationUser>();
                var role = await RoleManager.FindByIdAsync("3a6e2158-8b77-4ff8-9c15-66a48e00248e");
                foreach (var user in UserManager.Users.ToList())
                {
                    if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                    {
                        users.Add(user);
                    }
                }
                ApprovalProcessViewModel model = new ApprovalProcessViewModel
                {
                    ApproverList = users
                };
                return View(model);
            }
            else
            {

                List<String> Approvers = approvers.Approver;
                List<int> Levels = approvers.Level;

                foreach (var level in Levels)
                {
                    for (var i = 0; i < level; i++)
                    {
                        
                    }
                }

                return Content(Approvers[0] + " " + Approvers[1] + " " + Levels[0] + " " + Levels[1]);



            }
            
        }
        

        public ActionResult Test()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(TestViewModel T)
        {
            IEnumerable<int> values = T.test;

            return Content(values.Count().ToString());
        }
    }
}