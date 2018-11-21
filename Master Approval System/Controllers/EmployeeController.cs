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
                msg.State = "Normal";
                msg.Message = "Employee Created Successfully !!";
            }

            return RedirectToAction("redirectView", "Dashboard", new { Message = msg.Message, Status = msg.State });

        }

        public ActionResult AddApprovalProcess()
        {
            return View();
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