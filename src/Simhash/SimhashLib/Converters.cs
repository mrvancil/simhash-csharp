using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhashLib
{
    public class Converters
    {
        public static string convert_ulong_to_bin(ulong value)
        {
            if (value == 0) return "0";
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            return b.ToString();
        }

        public static string ConvertulongToString(ulong value)
        {
            StringBuilder b = new StringBuilder();
            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            return b.ToString();
        }

        public static long ConvertUlongToLong(ulong value)
        {
            if (value == 0)
            {
                return 0;
            }

            StringBuilder b = new StringBuilder();
            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            string sUlong = b.ToString();
            long cLong = Convert.ToInt64(sUlong, 2);

            return cLong;
        }
    }
}
