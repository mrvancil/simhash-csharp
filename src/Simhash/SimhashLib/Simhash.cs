using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SimhashLib
{
    public class Simhash
    {
        public int fpSize = 64;

        public ulong value { get; set; }
        public Simhash()
        {
        }

        public Simhash(List<string> features)
        {
            build_by_features(features);
        }
        public Simhash(string content)
        {
            //convert to unicode? not sure if needed>>>>
            //byte[] utf8Bytes = Encoding.Default.GetBytes(content);
            //string unicodeValue = Encoding.Unicode.GetString(utf8Bytes);
            //build_by_text(unicodeValue);
            build_by_text(content);
        }

        public Simhash(Simhash simHash)
        {
            value = simHash.value;
        }
        public Simhash(ulong fingerPrint)
        {
            value = fingerPrint;
        }
        public int distance(Simhash another)
        {
            if (fpSize != another.fpSize) throw new Exception();
            ulong x = (value ^ another.value) & (ulong.MaxValue);
            int ans = 0;
            while(x>0)
            {
                ans++;
                x &= x - 1;
            }
            return ans;
        }
        private void build_by_text(string content)
        {
            var shingles = tokenize(content);
            //grouped feature missing >>>>>>
            build_by_features(shingles);
        }

        public List<string> slide (string content, int width = 4)
        {
            var listOfShingles = new List<string>();
            for(int i=0;i<(content.Length + 1 - width);i++)
            {             
                string piece = content.Substring(i, width);
                listOfShingles.Add(piece);
            }
            return listOfShingles;
        }
        public string scrub(string content)
        {
            MatchCollection matches = Regex.Matches(content, @"[\w\u4e00-\u9fcc]+");
            string ans = "";
            foreach (Match match in matches)
            {
                ans += match.Value;
            }

            return ans;
        }

        public List<string> tokenize(string content)
        {
            content = content.ToLower();
            content = scrub(content);
            return slide(content);
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

            value = makeFingerprint(v, masks);
        }

        private ulong makeFingerprint(int[] v, ulong[] masks)
        {
            ulong ans = 0;
            for (int i = 0; i < fpSize; i++)
            {
                if (v[i] >= 0)
                {
                    ans |= masks[i];
                }
            }
            return ans;
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
    }
}
