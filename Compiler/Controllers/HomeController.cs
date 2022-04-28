using Compiler.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Compiler.Controllers
{
    public class HomeController : Controller
    {

        List<string> match = new List<string>();
     

        public IActionResult Editor()
        {


            return View();
        }
        /*public JsonResult GetSearchValue(string search)
        {
            match.Add("if");
            match.Add("include");
            match.Add("Slowf");
            match.Add("Loli");
            match.Add("Loopwhen");

            List<String> allsearch = match.Where(x => x.Contains(search)).ToList();
            return new JsonResult ( allsearch,JsonRequestBehavior.AllowGet );
        }
        */
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
