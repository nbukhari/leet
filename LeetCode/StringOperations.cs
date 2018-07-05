using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class StringOperations
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 0)
                return new List<IList<string>>();

            Dictionary<string, IList<string>> ans = new Dictionary<string, IList<string>>();
            int length = 26;
            int[] count = null;

            foreach (string s in strs)
            {
                count = Enumerable.Repeat(0, length).ToArray();
                foreach (char c in s) count[c - 'a']++;

                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < length; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                String key = sb.ToString();
                if (!ans.ContainsKey(key)) ans.Add(key, new List<string>());
                ans[key].Add(s);
            }
            return ans.Values.ToList();
        }

        /// <summary>
        /// Count and Say
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(N)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public String CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                StringBuilder result = new StringBuilder();
                String s = CountAndSay(n - 1);
                int len = s.Length;
                int i = 0;
                while (i < len)
                {
                    int count = 1;
                    char ch = s[i++];
                    while (i < len && s[i] == ch)
                    {
                        ++count;
                        ++i;
                    }
                    result.Append(count).Append(ch);
                }
                return result.ToString();
            }
        }

        /// <summary>
        /// Encode and Decode TinyURL
        /// The number of URLs that can be encoded is quite large in this case, nearly of the order (10+26*2)^6
        /// https://leetcode.com/articles/encode-and-decode-tinyurl/
        /// https://leetcode.com/problems/encode-and-decode-tinyurl/discuss/122042/C-Solution
        /// </summary>
        Hashtable hash1 = new Hashtable();
        Hashtable hash2 = new Hashtable();
        string shortStringSource = "abcdefthijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            StringBuilder shortString = new StringBuilder();

            if (longUrl == null || longUrl == string.Empty)
                return string.Empty;
            else if (hash1.ContainsKey(longUrl))
                return (string)hash1[longUrl];

            for (int i = 0; i <= 5; i++)
                shortString.Append(shortStringSource[new Random().Next(0, 61)]);

            hash1.Add(longUrl, "http://tinyurl.com/" + shortString.ToString());
            hash2.Add("http://tinyurl.com/" + shortString.ToString(), longUrl);

            return "http://tinyurl.com/" + shortString.ToString();
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return (string)hash2[shortUrl];
        }

        private Dictionary<char, int> RomanNumerals = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public int RomanToInt(string s)
        {
            int sum = 0;
            int maxSeen = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];

                // Add if greater than or equal to best seen
                if (RomanNumerals[c] >= maxSeen)
                {
                    sum += RomanNumerals[c];
                    maxSeen = RomanNumerals[c];
                    continue;
                }

                // Else subtract
                sum -= RomanNumerals[c];
            }

            return sum;
        }

        public bool IsValidParanthese(string s)
        {
            char[] stack = new char[s.Length];
            int stack_ptr = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack[stack_ptr++] = s[i];
                }
                else if (stack_ptr != 0)
                {
                    if (s[i] == ')')
                    {
                        if (stack[stack_ptr - 1] == '(')
                            stack_ptr--;
                        else
                            return false;
                    }
                    else if (s[i] == ']')
                    {
                        if (stack[stack_ptr - 1] == '[')
                            stack_ptr--;
                        else
                            return false;
                    }
                    else if (s[i] == '}')
                    {
                        if (stack[stack_ptr - 1] == '{')
                            stack_ptr--;
                        else
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return stack_ptr == 0;
        }

        public bool IsValidNumber(string s)
        {
            decimal dec;
            bool result = false;
            try
            {
                dec = Convert.ToDecimal(s);
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool ValidPalindrome(string s)
        {
            int lower = 0;
            int higher = s.Length - 1;
            bool isRemoved = false;

            while (lower < higher)
            {
                if (s[lower] != s[higher])
                {
                    if (isRemoved)
                    {
                        return false;
                    }
                    if (s[lower] == s[higher - 1])
                    {
                        isRemoved = true;
                        higher--;
                        continue;
                    }
                    else if (s[lower + 1] == s[higher])
                    {
                        isRemoved = true;
                        lower++;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                lower++;
                higher--;
            }

            return true;
        }

        public bool IsPalindrome(string s)
        {
            if (s.Length == 0)
                return true;

            int lower = 0;
            int higher = s.Length - 1;
            s = s.ToLower();

            while (lower < higher)
            {
                if (IsNotAlphanumeric(s[lower]))
                {
                    lower++;
                    continue;
                }

                if (IsNotAlphanumeric(s[higher]))
                {
                    higher--;
                    continue;
                }

                if (s[lower] != s[higher])
                    return false;

                lower++;
                higher--;
            }

            return true;
        }

        private bool IsNotAlphanumeric(char ch)
        {
            return !(((ch - '0' >= 0) && (ch - '9' <= 0)) || ((ch - 'A' > -1) && (ch - 'Z' < 1)) ||
                ((ch - 'a' > -1) && (ch - 'z' < 1)));
        }
    }
}
