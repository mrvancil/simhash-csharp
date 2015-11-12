using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhashLib
{
    public class Simhash
    {
        public long value { get; set; }
        public Simhash(List<string> features)
        {
            value = 0;
        }

    }
}
