using System;
using System.Collections.Generic;
using System.Linq;

namespace SimhashLib
{
    public class SimhashIndex
    {
        public static int fpSizeStatic = 64;
        public int kDistance;
        public int fpSize = fpSizeStatic;
        public Dictionary<string, HashSet<string>> bucket;
        public static List<int> offsets;

        //whitepaper says 64 and 3 are optimal. the ash tray says you've been up all night...
        public SimhashIndex(Dictionary<long, Simhash> objs, int f = 64, int k = 3)
        {
            this.kDistance = k;
            this.fpSize = f;
            var bucketHashSet = new HashSet<string>();
            bucket = new Dictionary<string, HashSet<string>>();

            offsets = make_offsets();

            foreach (KeyValuePair<long, Simhash> q in objs)
            {
                add(q.Key, q.Value);
            }
        }

        public HashSet<long> get_near_dups(Simhash simhash)
        {
            /*
            "simhash" is an instance of Simhash
            return a list of obj_id, which is in type of long (for now)
            */
            if (simhash.fpSize != this.fpSize) throw new Exception();
            
            var ans = new HashSet<long>();

            foreach (string key in get_keys(simhash))
            {
                if (bucket.ContainsKey(key))
                {
                    var dups = bucket[key];
                    foreach (var dup in dups)
                    {
                        string[] parts = dup.Split(',');
                        ulong fp = Convert.ToUInt64(parts[0]);
                        long obj_id = Convert.ToInt64(parts[1]);
                        var sim2 = new Simhash(fp);
                        int d = simhash.distance(sim2);
                        if (d <= kDistance)
                        {
                            ans.Add(obj_id);
                        }
                    }
                }
            }
            return ans;
        }
        public void add(long obj_id, Simhash simhash)
        {
            foreach (string key in get_keys(simhash))
            {
                string v = string.Format("{0},{1}", simhash.value, obj_id);
                if (!bucket.ContainsKey(key))
                {
                    var bucketHashSet = new HashSet<string>() { v };
                    bucket.Add(key, bucketHashSet);
                }
                else
                {
                    var values = bucket[key];
                    values.Add(v);
                }
            }
        }

        public void delete(long obj_id, Simhash simhash)
        {
            foreach (string key in get_keys(simhash))
            {
                string v = string.Format("{0},{1}", simhash.value, obj_id);
                if (bucket.ContainsKey(key))
                {
                    bucket[key].Remove(v);
                }
            }
        }

        public List<int> make_offsets()
        {
            /*
            You may optimize this method according to < http://www.wwwconference.org/www2007/papers/paper215.pdf>
            */
            //int optimizedSize = 4; replace kDistance with this var.
            //
            var ans = new List<int>();
            for (int i = 0; i < (kDistance + 1); i++)
            {
                int offset = fpSize / (kDistance + 1) * i;
                ans.Add(offset);
            }
            return ans;
        }

        public List<string> get_the_keys(Simhash simhash)
        {
            return get_keys(simhash).ToList();
        }
        private static IEnumerable<string> get_keys(Simhash simhash)
        {
            for (int i = 0; i < offsets.Count; i++)
            {
                int off;
                if (i == (offsets.Count - 1))
                {
                    off = (fpSizeStatic - offsets[i]);
                }
                else
                {
                    off = offsets[i + 1] - offsets[i];
                }

                double m = (Math.Pow(2, off)) - 1;
                ulong m64 = Convert.ToUInt64(m);
                ulong offset64 = Convert.ToUInt64(offsets[i]);
                ulong c = simhash.value >> offsets[i] & m64;

                yield return string.Format("{0},{1}", c, i);
            }
        }
    }
}
