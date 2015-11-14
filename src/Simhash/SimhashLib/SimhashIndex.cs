using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhashLib
{
    public class SimhashIndex
    {
        public int kDistance;
        public int fpSize = 64;
        public Dictionary<string, string> bucket;
        public List<int> offsets;

        public SimhashIndex(Dictionary<long,Simhash> objs, int f = 64, int k=2 )
        {
            this.kDistance = k;
            this.fpSize = f;
            //Console.WriteLine("Initializing {0} data.", objs.Count);
            bucket = new Dictionary<string, string>();

            make_offsets();

            foreach(KeyValuePair<long, Simhash> q in objs)
            {
                add(q.Key, q.Value);
            }

        }
        private void add(long obj_id, Simhash simhash)
        {
            //foreach(string key in get_keys(simhash))
            //{ }


        }
        public List<int> make_offsets()
        {
            var ans = new List<int>();
            for (int i=0;i<(kDistance+1);i++)
            {
                int offset = fpSize / (kDistance + 1) * i;
                ans.Add(offset);
            }
            return ans;
        }

        //public static IEnumerable<string> get_keys(Simhash simhash)
        //{

        //    for (int i = 0; i < exponent; i++)
        //    {
        //        result = result * number;
        //        yield return result;
        //    }
        //}


        public HashSet<long> get_near_dups(Simhash simhash)
        {
            /*
            "simhash" is an instance of Simhash
            return a list of obj_id, which is in type of long (for now)
            */
            if (simhash.fpSize != this.fpSize) throw new Exception();


            var ans = new HashSet<long>();
            return ans;
        }


    }
}
