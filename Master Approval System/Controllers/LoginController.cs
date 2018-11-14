using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_Approval_System.Models;
using Master_Approval_System.ViewModels;

namespace Master_Approval_System.Controllers
{
    public class LoginController : Controller
    {

        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Login

        public ActionResult Login()
        {
            ViewBag.Message = "Login Page.";

            return View();
        }

        public ActionResult EmployeeLogin()
        {
            throw new NotImplementedException();
        }

        public ActionResult AdminLogin(Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AccountsLoginViewModel()
                {
                    Administrator = administrator
                };
                return View("Login", viewModel);
            }

            var admin = _context.Employees.SingleOrDefault(c => c.Email == administrator.Email && c.Password == administrator.Password);
            if (admin == null)
            {
                return Content("not found!!");
            }
            else
            {
                return Content("found!!");
            }

        }
    }
}