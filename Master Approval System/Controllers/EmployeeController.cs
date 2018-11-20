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

            DashboardMessageViewModel message = new DashboardMessageViewModel();

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

            //Add default User to Role Admin   
            if (chkUser.Succeeded)
            {
                message.State = "Normal";
                message.Message = "Employee Created Successfully !!";
            }

            message.State = "Error";
            message.Message = "Error during creation !!";

            return RedirectToAction("Index", "Dashboard", new {info = message});

        }
    }
}