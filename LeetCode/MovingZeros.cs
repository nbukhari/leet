using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MovingZeros
    {
        public void MoveZeroesToEnds(int[] nums)
        {
            int n = nums.Length;
            int lower = 0, higher = 0, zeros = 0;

            while (lower < n && nums[lower] != 0) lower++;

            for (higher = lower + 1; higher < n; higher++)
            {
                if (nums[higher] != 0)
                {
                    int temp = nums[lower];
                    nums[lower++] = nums[higher];
                    nums[higher] = temp;
                }
            }

            zeros = n - lower;
            int i = (int)Math.Ceiling(zeros / 2.0);

            ArrayOperations arrayOperations = new ArrayOperations();
            arrayOperations.RotateArray(nums, n - i - 1, n - 1);
        }

        public void MoveZeroes(int[] nums)
        {
            if (nums == null)
                return;

            int n = nums.Length;
            int higher = 1;
            int lower = 0;

            if (n < 2)
                return;

            while (higher < n && lower < n)
            {
                if (nums[lower] == 0 && nums[higher] != 0)
                {
                    nums[lower] = nums[higher];
                    nums[higher] = 0;
                    higher++;
                    lower++;
                }
                else
                {
                    higher++;
                    if (nums[lower] != 0)
                    {
                        lower++;
                        continue;
                    }
                }
            }
        }
    }
}
