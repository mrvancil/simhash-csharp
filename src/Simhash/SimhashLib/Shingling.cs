using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimhashLib
{
    public class Shingling
    {
        public List<string> slide(string content, int width = 4)
        {
            var listOfShingles = new List<string>();
            for (int i = 0; i < (content.Length + 1 - width); i++)
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

        public List<string> tokenize(string content, int width = 4)
        {
            content = content.ToLower();
            content = scrub(content);
            return slide(content, width);
        }
    }
}
