using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DPOperations
    {
        /// <summary>
        /// Maximum Sum of 3 Non-Overlapping Subarrays
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(N)
        /// Note: Need to work to understand the solution
        /// https://leetcode.com/problems/maximum-sum-of-3-non-overlapping-subarrays/discuss/108231/C++Java-DP-with-explanation-O(n)
        /// https://www.geeksforgeeks.org/maximum-sum-two-non-overlapping-subarrays-of-given-size/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            int n = nums.Length, maxsum = 0;
            int[] sum = new int[n + 1], posLeft = new int[n], posRight = new int[n], ans = new int[3];
            for (int i = 0; i < n; i++) sum[i + 1] = sum[i] + nums[i];
            // DP for starting index of the left max sum interval
            for (int i = k, tot = sum[k] - sum[0]; i < n; i++)
            {
                if (sum[i + 1] - sum[i + 1 - k] > tot)
                {
                    posLeft[i] = i + 1 - k;
                    tot = sum[i + 1] - sum[i + 1 - k];
                }
                else
                    posLeft[i] = posLeft[i - 1];
            }
            // DP for starting index of the right max sum interval
            // caution: the condition is ">= tot" for right interval, and "> tot" for left interval
            posRight[n - k] = n - k;
            for (int i = n - k - 1, tot = sum[n] - sum[n - k]; i >= 0; i--)
            {
                if (sum[i + k] - sum[i] >= tot)
                {
                    posRight[i] = i;
                    tot = sum[i + k] - sum[i];
                }
                else
                    posRight[i] = posRight[i + 1];
            }
            // test all possible middle interval
            for (int i = k; i <= n - 2 * k; i++)
            {
                int l = posLeft[i - 1], r = posRight[i + k];
                int tot = (sum[i + k] - sum[i]) + (sum[l + k] - sum[l]) + (sum[r + k] - sum[r]);
                if (tot > maxsum)
                {
                    maxsum = tot;
                    ans[0] = l; ans[1] = i; ans[2] = r;
                }
            }
            return ans;
        }

        /// <summary>
        /// Minimum Window Subsequence
        /// Note: Find better solution with binary search
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public string MinWindow(string S, string T)
        {
            int len1 = S.Length;
            int len2 = T.Length;

            int[][] dp = new int[len2][];
            for (int i = 0; i < len2; i++)
            {
                dp[i] = new int[len1];
                for (int j = 0; j < len1; j++)
                {
                    dp[i][j] = -1;
                }
            }

            for (int j = 0; j < len1; j++)
            {
                dp[0][j] = (S[j] == T[0]) ? j : -1;
            }

            for (int i = 1; i < len2; i++)
            {
                int last = -1;
                for (int j = 0; j < len1; j++)
                {
                    if (last >= 0 && S[j] == T[i])
                    {
                        dp[i][j] = last;
                    }
                    if (dp[i - 1][j] >= 0)
                    {
                        last = dp[i - 1][j];
                    }
                }
            }

            int start = -1;
            int length = Int32.MaxValue;

            for (int j = 0; j < len1; j++)
            {
                if (dp[len2 - 1][j] >= 0 && (j - dp[len2 - 1][j] + 1 < length))
                {
                    start = dp[len2 - 1][j];
                    length = j - dp[len2 - 1][j] + 1;
                }
            }

            return (start == -1) ? "" : S.Substring(start, length);
        }

        /// <summary>
        /// A message containing letters from A-Z is being encoded to numbers
        /// Find Number of ways to decode a message
        /// Time Complexity
        ///     O(n)
        /// Space Complexity
        ///     O(1)
        /// http://www.gorecursion.com/algorithm/2016/11/20/1d-dynamic1.html
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            int n = s.Length;
            int f0 = 1;
            int f1 = s[0] != '0' ? 1 : 0;
            int f2 = f1;
            if (n == 1)
                return f1;
            for (int i = 1; i < n; i++)
            {
                if (s[i] != '0')
                    f2 = f1;
                else
                    f2 = 0;
                int v = Convert.ToInt32(s.Substring(i - 1, i + 1));
                if (v >= 10 && v <= 26)
                    f2 += f0;
                f0 = f1;
                f1 = f2;
            }
            return f2;
        }

        /// <summary>
        /// Best Time to Buy and Sell Stock
        /// Time Complexity
        ///     O(n)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int minprice = Int32.MaxValue;
            int maxprofit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                    minprice = prices[i];
                else if (prices[i] - minprice > maxprofit)
                    maxprofit = prices[i] - minprice;
            }

            return maxprofit;
        }
    }
}
