using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master_Approval_System.ViewModels;

namespace Master_Approval_System.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            DashboardMessageViewModel model = new DashboardMessageViewModel();
            model.Message = "Everything is working fine !!";
            model.State = "Normal";
            return View(model);
        }


    }
}