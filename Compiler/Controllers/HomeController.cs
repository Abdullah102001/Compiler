
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;


namespace Compiler.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Editor()
        { 
            return View();
        }
        public String ReadFile(IFormFile file)
        {
            //FileStream path = System.IO.File.Create(file.FileName);
            string Tokens = null;
            if (file != null)
            {
                var dir = _env.ContentRootPath;
                string path = Path.Combine(dir, file.FileName);
                using (StreamReader r = new StreamReader(path))
                {
                    Tokens = r.ReadToEnd();


                }
            }
            return Tokens;
        }
        
       

    }
}