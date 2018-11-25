using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_Approval_System.Models;
using Master_Approval_System.ViewModels;

namespace Master_Approval_System.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult createProfileUpdateRequest()
        {
            ProfileUpdateRequestViewModel profile = new ProfileUpdateRequestViewModel();
            return View(profile);
        }
    }
}