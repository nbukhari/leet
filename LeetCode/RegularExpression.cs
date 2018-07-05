using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RegularExpressions
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, new HashSet<string>());
        }

        private bool IsMatch(string s, string p, HashSet<string> visited)
        {
            var k = s + "#" + p;
            if (visited.Contains(k)) return false;
            var r = IsMatchCore(s, p, visited);
            if (!r) visited.Add(k);
            return r;
        }

        private bool IsMatchCore(string s, string p, HashSet<string> visited)
        {
            if (p.Length == 0) return s.Length == 0;
            if (p.Length == 1) return s.Length == 1 && (s[0] == p[0] || p[0] == '.');
            if (p[1] == '*')
            {
                if (IsMatch(s, p.Substring(2), visited)) return true;
                if (s.Length > 0 && (s[0] == p[0] || p[0] == '.'))
                {
                    if (IsMatch(s.Substring(1), p, visited)) return true;
                    if (IsMatch(s.Substring(1), p.Substring(2), visited)) return true;
                }
            }
            return s.Length > 0
                && (s[0] == p[0] || p[0] == '.')
                && IsMatch(s.Substring(1), p.Substring(1), visited);
        }
    }

    public class RegularExpression
    {
        private static String src;
        private static String pat;

        public bool IsMatch(string s, string p)
        {
            src = s;
            pat = p;

            int[][] dp = new int[s.Length + 1][];
            for (int i = 0; i < s.Length + 1; i++)
            {
                dp[i] = new int[p.Length + 1];
            }
            return isMatching(dp, s.Length, p.Length);
        }

        private bool isMatching(int[][] dp, int lens, int lenp)
        {
            bool res = false;

            if (lens == 0 && lenp == 0)
            {
                return true;
            }

            if (dp[lens][lenp] != 0)
            {
                return dp[lens][lenp] == 1 ? true : false;
            }

            if (lens == 0)
            {
                res = lenp >= 2 && pat[lenp - 1] == '*' && isMatching(dp, lens, lenp - 2);
                dp[lens][lenp] = res ? 1 : 2;
                return res;
            }

            if (lenp == 0)
            {
                return false;
            }

            if (pat[lenp - 1] == '.')
            {
                res = isMatching(dp, lens - 1, lenp - 1);
                dp[lens][lenp] = res ? 1 : 2;
                return res;
            }

            if (pat[lenp - 1] == '*')
            {
                res = isMatching(dp, lens, lenp - 2) || ((pat[lenp - 2] == '.' || pat[lenp - 2] == src[lens - 1]) && isMatching(dp, lens - 1, lenp));
                dp[lens][lenp] = res ? 1 : 2;
                return res;
            }

            res = (pat[lenp - 1] == src[lens - 1]) && isMatching(dp, lens - 1, lenp - 1);
            dp[lens][lenp] = res ? 1 : 2;
            return res;
        }
    }
}
