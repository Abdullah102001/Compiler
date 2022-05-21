
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
        List<string> Righttokens = new List<string>();
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
            List<Token> tokens;
            Scanner scanner = new Scanner();
            ScannerS.Scanner.Code = str; 
            tokens = scanner.Scanner1();
            return PrintTokens(tokens);
        }

        [HttpPost]
        public string Parser(string str)
        {
            List<Token> tokens;
            Scanner scanner = new Scanner();
            ScannerS.Scanner.Code = str;
            tokens = scanner.Scanner1();
            Parser parser = new Parser(tokens);
            List<GrammerSeq> grammerResult = new List<GrammerSeq>();
            grammerResult = parser.Parse();
            return WriteMatchedGrammer(grammerResult);
        }

        private string WriteMatchedGrammer(List<GrammerSeq> GrammerResult)
        {
            string result = "";
            foreach (GrammerSeq g in GrammerResult)
            {
                result += "Line Number : " + g.LineNumber + " Matched\tRule used : " + g.NonTerminal;
                result += '\n';
            }
            return result;
        }

        public string PrintTokens(List<Token> Tokens)
        {
            var TokensString = "";
            foreach (Token token in Tokens)
            {
                if (token.TokenType != State.TOKENTYPE.DELIMITER || 
                    token.TokenType != State.TOKENTYPE.COMMENT ||
                    token.TokenType != State.TOKENTYPE.STR )
                {
                    TokensString += token.PrintToken();
                    TokensString += "\n";
                }
            }
            return TokensString;
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
        //ToDo Resolve Red line error when scanner is empty
        [HttpPost]
        public List<string> RedLine(String str)
        {
            
            string r="";
            //Scanner s = new Scanner();
            //ScannerS.Scanner.Code = str;
            //s.Scanner1();
            //Righttokens = s.Red_Line();

            return Righttokens;

        }

    }
}