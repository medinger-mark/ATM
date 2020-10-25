using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATMConsole {
    public class Utils {
        public static string GetDollarAmountFromString(string value) {
            string numberString = string.Empty;

            var doubleArray = GetDollarAmountsFromString(value.Trim());

            if (doubleArray.Count() > 0) 
            {
                numberString = doubleArray.First();
                if (numberString.IndexOf(".") != -1)
                {
                    var cutOff = numberString.IndexOf(".", numberString.IndexOf(".") + 1);
                    if (cutOff != -1) 
                    {
                        numberString = numberString.Substring(0, cutOff);
                    }
                }
            }

            return numberString;
        }

        public static IEnumerable<string> GetDollarAmountsFromString(string value) {
            return Regex.Split(value.Trim(), @"[^0-9\.]+")
                        .Where(c => c != "." && c.Trim() != "");
        }

        public static string GetBasePath()
        {
            using var processModule = Process.GetCurrentProcess().MainModule;
            return Path.GetDirectoryName(processModule?.FileName);
        }

    }
}