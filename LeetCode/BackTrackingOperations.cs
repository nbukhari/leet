using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BackTrackingOperations
    {
        public bool IsMatch(String text, String pattern)
        {
            bool[][] dp = new bool[text.Length + 1][];

            for (int i = text.Length; i >= 0; i--)
            {
                dp[i] = new bool[pattern.Length + 1];
                dp[text.Length][pattern.Length] = true;
                for (int j = pattern.Length - 1; j >= 0; j--)
                {
                    bool first_match = (i < text.Length &&
                                           (pattern[j] == text[i] ||
                                            pattern[j] == '.'));
                    if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                    {
                        dp[i][j] = dp[i][j + 2] || first_match && dp[i + 1][j];
                    }
                    else
                    {
                        dp[i][j] = first_match && dp[i + 1][j + 1];
                    }
                }
            }
            return dp[0][0];
        }

        public bool IsMatchWildCard(string s, string p)
        {
            if (s == null || p == null)
                return false;

            if (s.Length == 0 && p.Length == 0)
                return true;

            int star_index = -1;
            int s_index = 0, p_index = 0, match = 0;

            while (s_index < s.Length)
            {
                if (p_index < p.Length && (p[p_index] == '?' || s[s_index] == p[p_index]))
                {
                    s_index++;
                    p_index++;
                }
                else if (p_index < p.Length && p[p_index] == '*')
                {
                    star_index = p_index;
                    match = s_index;
                    p_index++;
                }
                else if (star_index != -1)
                {
                    p_index = star_index + 1;
                    match++;
                    s_index = match;
                }
                else
                {
                    return false;
                }
            }

            while (p_index < p.Length && p[p_index] == '*')
                p_index++;

            return p_index == p.Length;
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            if (s == null)
                return null;

            string temp, str;
            IList<string> results = new List<string>();
            HashSet<string> visit = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                str = queue.Dequeue();

                if (IsValidParantheses(str))
                {
                    results.Add(str);
                    continue;
                }

                for (int i = 0; i < str.Length; i++)
                {
                    if (!IsParantheses(str[i]))
                        continue;

                    temp = str.Remove(i, 1);

                    if (!visit.Contains(temp))
                    {
                        visit.Add(temp);
                    }
                }
            }

            return results;
        }

        private bool IsParantheses(char ch)
        {
            return ch == '(' || ch == ')';
        }

        private bool IsValidParantheses(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    count++;
                else if (str[i] == ')')
                    count--;
                if (count < 0)
                    return false;
            }

            return count == 0;
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums == null)
                return null;

            bool isFinished = false;
            int size = nums.Length;
            IList<IList<int>> results = new List<IList<int>>();

            Array.Sort(nums);

            while (!isFinished)
            {
                results.Add(new List<int>(nums));

                // Find the rightmost number which is smaller than its next
                // number. Let us call it 'first number'
                int i;
                for (i = size - 2; i >= 0; --i)
                    if (nums[i] < nums[i + 1])
                        break;

                // If there is no such number, all are sorted in decreasing order,
                // means we just printed the last permutation and we are done.
                if (i == -1)
                    isFinished = true;
                else
                {
                    // Find the ceil of 'first number' in right of first number.
                    // Ceil of a number is the smallest number greater than it
                    int ceilIndex = findCeil(nums, nums[i], i + 1, size - 1);

                    // Swap first and second number
                    Swap(nums, i, ceilIndex);

                    // Sort the list on right of 'first number'
                    Array.Sort(nums, i + 1, size - i - 1);
                }
            }

            return results;
        }

        // This function finds the index of the smallest number
        // which is greater than 'first' and is present in nums[l..h]
        private int findCeil(int[] nums, int first, int l, int h)
        {
            // initialize index of ceiling element
            int ceilIndex = l;

            // Now iterate through rest of the elements and find
            // the smallest number greater than 'first'
            for (int i = l + 1; i <= h; i++)
                if (nums[i] > first && nums[i] < nums[ceilIndex])
                    ceilIndex = i;

            return ceilIndex;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            if (nums == null)
                return null;

            Permutation(results, nums, 0, nums.Length - 1);

            return results;
        }

        private void Permutation(IList<IList<int>> results, int[] nums, int l, int r)
        {
            if (l == r)
                results.Add(new List<int>(nums));
            else
            {
                for (int i = l; i <= r; i++)
                {
                    Swap(nums, l, i);
                    Permutation(results, nums, l + 1, r);
                    Swap(nums, l, i); //backtrack
                }
            }
        }

        private void Swap(int[] nums, int l, int r)
        {
            int temp = nums[l];
            nums[l] = nums[r];
            nums[r] = temp;
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            var results = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return results;

            for (int i = 0; i < nums.Length; i++)
            {
                List<List<int>> temp = new List<List<int>>();

                foreach (List<int> numbers in results)
                {
                    temp.Add(new List<int>(numbers));
                }

                List<int> singleDigit = new List<int>();
                singleDigit.Add(nums[i]);
                results.Add(singleDigit);

                foreach (List<int> number in temp)
                {
                    number.Add(nums[i]);
                }

                foreach (List<int> number in temp)
                {
                    results.Add(number);
                }
            }

            results.Insert(0, new List<int>());

            return results;
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> ans = new List<string>();

            if (digits.Length == 0) return ans;

            string[] mapping = new String[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            ans.Add("");

            while (ans.First().Length != digits.Length)
            {
                string combination = ans[0];
                ans.RemoveAt(0);
                string mapKey = mapping[digits.ElementAt(combination.Length) - '0'];
                foreach (char c in mapKey.ToArray())
                {
                    ans.Add(combination + c);
                }
            }

            return ans;
        }
    }
}
