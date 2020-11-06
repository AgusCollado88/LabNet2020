using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1_EF.Extensions
{
    public static class StringExtensions
    {
        public static int ContarPalabras (this String str)

        {
            if (str.Length == 0)
                return 0;

            str = str.Trim();
            while (str.Contains("  "))
                str = str.Replace("  ", " ");
            return str.Split(' ').Length; ;
        }
    }
}
