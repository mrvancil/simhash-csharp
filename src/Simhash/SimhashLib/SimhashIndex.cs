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
        public static int fpSizeStatic = 64;
        public Dictionary<string, string> bucket;
        public static List<int> offsets;

        public SimhashIndex(Dictionary<long,Simhash> objs, int f = 64, int k=2 )
        {
            this.kDistance = k;
            this.fpSize = f;
            bucket = new Dictionary<string, string>();

            offsets =  make_offsets();

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
            /*
            You may optimize this method according to < http://www.wwwconference.org/www2007/papers/paper215.pdf>
            */
            var ans = new List<int>();
            for (int i=0;i<(kDistance+1);i++)
            {
                int offset = fpSize / (kDistance + 1) * i;
                ans.Add(offset);
            }
            return ans;
        }

        public List<string> get_keys(Simhash simhash)
        {
            var keys = new List<string>();
            for(int i=0; i<offsets.Count;i++)
            {
                double m;
                if (i == (offsets.Count - 1))
                {
                    var off = (fpSizeStatic - offsets[i]);
                    var ret = Math.Pow(2, off);
                    m = ret - 1;
                }
                else
                {
                    var off = offsets[i + 1] - offsets[i];
                    var ret = Math.Pow(2, off);
                    m = ret - 1;
                    //int  m = 2 * *(self.offsets[i + 1] - offset) - 1
                }
                ulong m64 = Convert.ToUInt64(m);
                ulong offset64 = Convert.ToUInt64(offsets[i]);
                //0,31,26L
                ulong c = simhash.value >> offsets[i] & m64;
                keys.Add(string.Format("{0},{1}", c, i));
            }
            return keys;
        }


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
