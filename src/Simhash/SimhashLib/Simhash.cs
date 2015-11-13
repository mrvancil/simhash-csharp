using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace SimhashLib
{
    public class Simhash
    {
        const int fpSize = 64;

        public ulong value { get; set; }
        public Simhash()
        {
        }

        public Simhash(List<string> features)
        {
            build_by_features(features);
        }

        private void build_by_features(List<string> features)
        {
            /*
                "features" might be a list of unweighted tokens(a weight of 1
                will be assumed), a list of(token, weight) tuples or
                a token -> weight dict.
            */

            int[] v = setupFingerprint();
            ulong[] masks = setupMasks();

            foreach (string feature in features)
            {
                BigInteger h = hashfunc(feature);
                int w = 1;
                for (int i = 0; i < fpSize; i++)
                {
                    //convert to BigInt so we can use BitWise
                    BigInteger bMask = masks[i];
                    BigInteger result = h & bMask;
                    v[i] += (result > 0) ? w : -w;
                }
            }

            ulong ans = 0;
            //ulong uans = 0;
            for (int i = 0; i<fpSize; i++)
            {
                if (v[i] >= 0)
                {
                    ans |= masks[i];
                }
            }
            value = ans;
         }

        private int[] setupFingerprint()
        {
            int[] v = new int[fpSize];
            for (int i = 0; i < v.Length; i++) v[i] = 0;
            return v;
        }

        private ulong[] setupMasks()
        {
            ulong[] masks = new ulong[fpSize];
            for (int i = 0; i < masks.Length; i++)
            {
                masks[i] = (ulong)1 << i;
            }
            return masks;
        }

        private BigInteger hashfunc(string x)
        {
            string hexValue = hashfunc_hashtostring(x);
            BigInteger b = hashfunc_hashstringtobignasty(hexValue);
            return b;
        }
        public string hashfunc_hashtostring(string x)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(x));

                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public BigInteger hashfunc_hashstringtobignasty(string x)
        {
            BigInteger bigNumber = BigInteger.Parse(x, NumberStyles.AllowHexSpecifier);
            return bigNumber;
        }
    }
}
