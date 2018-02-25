using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BarSzybkiejObsługiMVC.Utility
{
    public static class CodeGenerator
    {
        private static int lengthOfCode = 8;
        public static string Generate()
        {
            string code = Guid.NewGuid().ToString().Substring(0, lengthOfCode).ToUpper();

            while (code.Contains("0") || code.Contains("o") || 
                   code.Contains("O") || code.Contains("i") ||
                   code.Contains("L") ||code.Contains("l") || code.Contains("I"))
            {
                code = Guid.NewGuid().ToString().Substring(0, lengthOfCode).ToUpper();
            }

            return code;
        }
    }
}