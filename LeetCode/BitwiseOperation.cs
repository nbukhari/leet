using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BitwiseOperation
    {
        /// <summary>
        /// Hamming Distance
        /// The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
        /// https://en.wikipedia.org/wiki/Hamming_distance
        /// Time Complexity
        ///     O(1)
        /// Space Complexity
        ///     0(1)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            int dist = 0;
            int val = x ^ y;

            // Count the number of bits set
            while (val != 0)
            {
                // A bit is set, so increment the count and clear the bit
                dist++;
                val &= val - 1;
            }

            // Return the number of differing bits
            return dist;
        }

        /// <summary>
        /// This is better when most bits in x are 0
        /// This is algorithm works the same for all data sizes.
        /// This algorithm uses 3 arithmetic operations and 1 comparison/branch per "1" bit in x.
        /// Time Complexity
        ///     O(1)
        /// Space Complexity
        ///     0(1)
        /// https://leetcode.com/articles/number-1-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int count;
            for (count = 0; n > 0; count++)
                n &= n - 1;
            return count;
        }
    }
}
