using System;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SimhashLib
{

    public class Simhash
    {
        public enum HashingType {
            MD5,
            Jenkins
        }
        public int fpSize = 64;

        public ulong value { get; set; }

        public Simhash()
        {
        }
        public Simhash(HashingType hashingType)
        {
            hashAlgorithm = hashingType;
        }

        public Simhash(Simhash simHash)
        {
            value = simHash.value;
        }
        public Simhash(ulong fingerPrint)
        {
            value = fingerPrint;
        }

        public void GenerateSimhash(string content)
        {
            var shingling = new Shingling();
            var shingles = shingling.tokenize(content);
            GenerateSimhash(shingles);
        }

        //playing around with hashing algorithms. turns out md5 is a touch slow.
        private HashingType hashAlgorithm = HashingType.Jenkins;

        public void GenerateSimhash(List<string> features)
        {
            switch(hashAlgorithm)
            {
                case HashingType.MD5:
                    build_by_features_md5(features);
                    break;
                default:
                    build_by_features_jenkins(features);
                    break;

            }
        }

        public long GetFingerprintAsLong()
        {
            return Converters.ConvertUlongToLong(value);
        }

        public int distance(Simhash another)
        {
            if (fpSize != another.fpSize) throw new Exception();
            ulong x = (value ^ another.value) & (ulong.MaxValue);
            int ans = 0;
            while (x > 0)
            {
                ans++;
                x &= x - 1;
            }
            return ans;
        }
        private void build_by_features_jenkins(List<string> features)
        {
            int[] v = setupFingerprint();
            ulong[] masks = setupMasks();

            foreach (string feature in features)
            {
                ulong h = hashfuncjenkins(feature);
                int w = 1;
                for (int i = 0; i < fpSize; i++)
                {
                    ulong result = h & masks[i];
                    v[i] += (result > 0) ? w : -w;
                }
            }

            value = makeFingerprint(v, masks);
        }
       
        private void build_by_features_md5(List<string> features)
        {
            int[] v = setupFingerprint();
            ulong[] masks = setupMasks();

            foreach (string feature in features)
            {
                //this is using MD5 which is REALLY slow
                BigInteger h = hashfuncmd5(feature);
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

        public ulong hashfuncjenkins(string x)
        {
            var jenkinsLookup3 = new JenkinsLookup3(64);
            var resultBytes = jenkinsLookup3.ComputeHash(x);

            var y = BitConverter.ToUInt64(resultBytes,0);

            return y;
        }

        private BigInteger hashfuncmd5(string x)
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

                string returnString = "";
                for (int i = 0; i < data.Length; i++)
                {
                    returnString += data[i].ToString("x2");
                }
                return returnString;
            }
        }

        public BigInteger hashfunc_hashstringtobignasty(string x)
        {
            BigInteger bigNumber = BigInteger.Parse(x, NumberStyles.AllowHexSpecifier);
            return bigNumber;
        }
    }
}
