
using ScannerS;
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
        private readonly IWebHostEnvironment _env;
        
        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Editor()
        { 
            return View();
        }

        [HttpPost]
        public string Scanner(string str)
        {
            var tokens = "";
            Scanner s = new Scanner();
            ScannerS.Scanner.Code = str; 
            tokens = s.Scanner1();
            return tokens;
        }

        [HttpPost]
        public string Parser(string str)
        {
            var token =  str;
            return token;
        }
        [HttpPost]
        public string ReadFile()
        {
            string Tokens = null;
            foreach (var formFile in Request.Form.Files)
            {

                var filePaths = new List<string>();
                if (formFile != null)
                {

                    var filePath = Path.GetTempFileName();
                    filePaths.Add(filePath);
                    using (var stream = formFile.OpenReadStream())
                    using (var reader = new StreamReader(stream))
                    {
                        Tokens = reader.ReadToEnd();
                    }
                }
            }
            return Tokens;
        }
        
       

    }
}