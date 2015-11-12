using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhashLib
{
    public class Simhash
    {
        const int f = 64;

        public long value { get; set; }
        public Simhash(List<string> features)
        {
            build_by_features(features);
            value = 0;
        }

        private void build_by_features(List<string> features)
        {
            /*
                "features" might be a list of unweighted tokens(a weight of 1
                will be assumed), a list of(token, weight) tuples or
                a token -> weight dict.
            */

            int[] v = setupFingerprint();
            long[] masks = setupMasks();

            foreach(string f in features)
            {
                
            }

        }

        private int[] setupFingerprint()
        {
            int[] v = new int[f];
            for (int i = 0; i < v.Length; i++) v[i] = 0;
            return v;
        }

        private long[] setupMasks()
        {
            long[] masks = new long[f];
            for (int i = 0; i < masks.Length; i++)
            {
                masks[i] = (long)1 << i;
            }
            return masks;
        }

        private int hashfunc(string x)
        {

            return 0;
        }
    }
}
