using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangout.Controllers
{
    public class TestViewController : Controller
    {
        // GET: TestView
        public ActionResult Index()
        {
            return View();
        }
    }
}