using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Helpers
{
    public static class Converter
    {
        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }
    }
}
