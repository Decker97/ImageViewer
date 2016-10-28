using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public static class DataConverters
    {

        public static int ToInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return i;
            else
                return int.MinValue;
        }

        public static decimal ToDecimal(this double d)
        {
            decimal dec;
            string s = d.ToString();
            if (decimal.TryParse(s, out dec))
                return dec;
            else
                return decimal.MinValue;
        }

        public static double ToDouble(this string s)
        {
            double d;
            if (double.TryParse(s, out d))
                return d;
            else
                return double.MinValue;
        }

        public static decimal ToDecimal(this string s)
        {
            decimal d;
            if (decimal.TryParse(s, out d))
                return d;
            else
                return decimal.MinValue;
        }

        public static DateTime ToDateTime(this string s)
        {
            DateTime d;
            if (DateTime.TryParse(s, out d))
                return d;
            else
                return DateTime.MinValue;
        }

        public static bool Tobool(this string s)
        {
            bool d;
            bool.TryParse(s, out d);
            return d;
        }
    }
}
