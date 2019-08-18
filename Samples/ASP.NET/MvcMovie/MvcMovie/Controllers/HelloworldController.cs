using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloworldController : Controller
    {
        // GET: Helloworld
        public ActionResult Index()
        //public string Index()
        {
            return View();
            //return "Hello World...";
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            //return HttpUtility.HtmlEncode("ここはWelcome: へろ～ " + name + " さん. numTimes = " + numTimes);
            ViewBag.Message = "ハロー" + name;
            ViewBag.NumTimes = numTimes;
            return View();
        }

        public string Login(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello" + name + " ID: " + ID);
        }
    }
}