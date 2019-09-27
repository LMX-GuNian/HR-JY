using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class TextController : Controller
    {
        // GET: Text
        public ActionResult Index()
        {
            TextBLL tb = IOC.ModelIOC.GetBLL<TextBLL>();
            List<TextModel> ltm = tb.Select();
            return View();
        }
    }
}