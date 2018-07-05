using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class NumberOperaions
    {
        /// <summary>
        /// Sqrt(x)
        /// Time Complexity
        ///     O(log(n)). For each value of r, we divide by 2
        ///     So the total time complexity is O(log(n)).
        /// Space Complexity
        ///     O(1). We only need one variables for the final result of x.
        /// Note: Solved using newton's method
        /// https://en.wikipedia.org/wiki/Integer_square_root#Using_only_integer_division
        /// https://leetcode.com/problems/sqrtx/discuss/25057/3-4-short-lines-Integer-Newton-Every-Language
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            long r = x;
            while (r * r > x)
                r = (r + x / r) / 2;
            return (int)r;
        }

        /// <summary>
        /// Pow(x, n)
        /// Implement pow(x, n), which calculates x raised to the power n (x^n).
        /// Time Complexity
        ///     O(log(n)). For each bit of n 's binary representation, we will at most multiply once. 
        ///     So the total time complexity is O(log(n)).
        /// Space Complexity
        ///     O(1). We only need two variables for the current product and the final result of x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (x == 0)
                return 0;

            if (n == 0)
                return 1;

            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            double ans = 1;
            double current_product = x;
            for (long i = N; i > 0; i /= 2)
            {
                if ((i % 2) == 1)
                {
                    ans = ans * current_product;
                }
                current_product = current_product * current_product;
            }
            return ans;
        }
    }
}
