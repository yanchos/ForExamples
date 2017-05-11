using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ForNinject;

namespace WebApplication1.Views.NinjectExamplePage
{
    public class NinjectExamplePageController : Controller
    {
        private IUserRepository rep;

        public NinjectExamplePageController(IUserRepository irep)
        {
            rep = irep;
        }

        // GET: NinjectExamplePage
        public ActionResult Index()
        {
            return View("NinjectExamplePage", rep.GetUsers());
        }
    }
}