using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InputReplacer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text)
        {
            string tempData = "";
            string result = "";
            foreach (var item in text)
            {
                if (char.IsLetter(item))
                {
                    tempData += item.ToString();
                }
                else
                {
                    if (tempData.Length > 1) result += tempData[0] + (tempData.Length - 2).ToString() + tempData[tempData.Length - 1] + item;
                    else result += tempData + item;
                    tempData = "";
                }
            }
            if (tempData != "" && tempData.Length > 1) result += tempData[0] + (tempData.Length - 2).ToString() + tempData[tempData.Length - 1];
            else result += tempData;

            ViewBag.Result = result;
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}