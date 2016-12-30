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
            int equalchar = 0;
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
                    if (tempData.Length > 1)
                    {
                        if (tempData.Length > 3) equalchar = CharCompare(tempData.Substring(1, tempData.Length - 2).ToLower());
                        result += tempData[0] + (tempData.Length - equalchar - 2).ToString() + tempData[tempData.Length - 1] + item;
                    }
                    else result += item;
                    tempData = "";
                }
            }

            if (tempData != "" && tempData.Length > 1)
            {
                if (tempData.Length >  3) equalchar = CharCompare(tempData.Substring(1, tempData.Length - 2).ToLower());
                result += tempData[0] + (tempData.Length - equalchar - 2).ToString() + tempData[tempData.Length - 1];  
            }
            else result += tempData;

            ViewBag.Result = result;
            return View();
        }

        private int CharCompare(string text)
        {
            int count = 0;
            int result=0;
            foreach (var letter in text.Distinct().ToArray())
            {
                count = text.Count(chr => chr == letter);
                result += count - 1;
            }
           
            return result;

        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}