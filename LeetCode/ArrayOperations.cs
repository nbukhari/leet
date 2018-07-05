using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MyComparer : IComparer<Int32>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class ArrayOperations
    {
        /// <summary>
        /// Remove Duplicates from Sorted Array
        /// Do not allocate extra space for another array, you must do this by modifying 
        /// the input array in-place with O(1) extra memory.
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return 1;

            int i = 0, j = 1;

            while (j < nums.Length)
            {
                if (nums[i] != nums[j])
                {
                    if (j - i > 1)
                    {
                        nums[i + 1] = nums[j];
                    }
                    i++;
                }
                j++;
            }

            return i + 1;
        }

        /// <summary>
        /// Product of Array Except Self
        /// One solution is to find product of all elements and 
        /// then loop to divide product with each element
        /// Note: Please solve it without division and in O(n).
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] res = Enumerable.Repeat(1, nums.Length).ToArray();
            int fromBegin = 1;
            int fromEnd = 1;
            for (int i = 0; i < nums.Length; ++i)
            {
                res[i] *= fromBegin;
                fromBegin *= nums[i];
                res[nums.Length - 1 - i] *= fromEnd;
                fromEnd *= nums[nums.Length - 1 - i];
            }
            return res;
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            int sum = 0;
            int start = 0, end = 0;
            int min_length = nums.Length + 1;

            while (end < nums.Length)
            {
                while (sum < s && end < nums.Length)
                {
                    if (sum <= 0 && s > 0)
                    {
                        start = end;
                        sum = 0;
                    }
                    sum += nums[end++];
                }

                while (sum >= s && start < nums.Length)
                {
                    if (end - start < min_length)
                        min_length = end - start;
                    sum -= nums[start++];
                }
            }

            if (nums.Length + 1 == min_length)
            {
                return 0;
            }

            return min_length;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            Array.Sort(nums);

            if (nums.Length < 3)
                return results;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int lower = i + 1;
                    int higher = nums.Length - 1;
                    int sum = 0 - nums[i];
                    while (lower < higher)
                    {
                        if (nums[lower] + nums[higher] == sum)
                        {
                            results.Add(new List<int> { nums[i], nums[lower], nums[higher] });
                            while (lower < higher && nums[lower] == nums[lower + 1]) lower++;
                            while (lower < higher && nums[higher] == nums[higher - 1]) higher--;
                            lower++;
                            higher--;
                        }
                        else if (nums[lower] + nums[higher] > sum)
                        {
                            higher--;
                        }
                        else
                        {
                            lower++;
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// The function assumes that there are at least two elements in array.
        /// Min
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MinDifference(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int arr_size = arr.Length;
            int i;
            for (i = 1; i < arr_size; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max - min;
        }

        /// <summary>
        /// The function assumes that there are at least two elements in array.
        /// Maximum difference between in any order
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxDiffAnyOrder(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int arr_size = arr.Length;
            int i;
            for (i = 1; i < arr_size; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max - min;
        }

        /// <summary>
        /// Maximum Difference in increasing order
        /// The function assumes that there are at least two elements in array.
        /// The function returns a negative value if the array is sorted in 
        /// decreasing order. Returns 0 if elements are equal 
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxDifferenceWithSum(int[] arr)
        {
            int n = arr.Length;
            // Initialize diff, current sum and max sum
            int diff = arr[1] - arr[0];
            int curr_sum = diff;
            int max_sum = curr_sum;

            for (int i = 1; i < n - 1; i++)
            {
                // Calculate current diff
                diff = arr[i + 1] - arr[i];

                // Calculate current sum
                if (curr_sum > 0)
                    curr_sum += diff;
                else
                    curr_sum = diff;

                // Update max sum, if needed
                if (curr_sum > max_sum)
                    max_sum = curr_sum;
            }

            return max_sum;
        }

        /// <summary>
        /// Maximum Difference in increasing order
        /// The function assumes that there are at least two elements in array.
        /// The function returns a negative value if the array is sorted in 
        /// decreasing order. Returns 0 if elements are equal 
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxDifference(int[] arr)
        {
            int arr_size = arr.Length;
            int max_diff = arr[1] - arr[0];
            int min_element = arr[0];
            int i;
            for (i = 1; i < arr_size; i++)
            {
                if (arr[i] - min_element > max_diff)
                    max_diff = arr[i] - min_element;
                if (arr[i] < min_element)
                    min_element = arr[i];
            }
            return max_diff;
        }

        public int GetLargestSum(int[] array, int n)
        {
            int largestSum = 0;
            int previousSum = 0;

            for (int i = 0; i <= array.Length - n; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        largestSum += array[j];
                    }

                    previousSum = largestSum;
                }
                else
                {
                    int currentSum = previousSum - array[i - 1] + array[i + n - 1];
                    if (currentSum > largestSum)
                    {
                        largestSum = currentSum;
                    }
                    previousSum = currentSum;
                }
            }

            return largestSum;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (map.ContainsKey(nums1[i])) map[nums1[i]] = map[nums1[i]] + 1;
                else map.Add(nums1[i], 1);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (map.ContainsKey(nums2[i]) && map[nums2[i]] > 0)
                {
                    result.Add(nums2[i]);
                    map[nums2[i]] = map[nums2[i]] - 1;
                }
            }

            int[] r = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                r[i] = result[i];
            }

            return r;
        }

        public int[] SortAndIntersect(int[] nums1, int[] nums2)
        {
            MyComparer comparer = new MyComparer();

            Array.Sort(nums1);
            Array.Sort(nums2);

            return IntersectSorted(nums1, nums2);
        }

        public int[] IntersectSorted(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0;
            List<Int32> intersection = new List<Int32>();

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    intersection.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return intersection.ToArray();
        }

        public void RotateArray(int[] array, int d, int n)
        {
            ReverseArray(array, 0, d);
            ReverseArray(array, d + 1, n);
            ReverseArray(array, 0, n);
        }

        public void ReverseArray(int[] array, int start, int end)
        {
            int lower = start, higher = end;

            while (lower < higher)
            {
                int temp = array[lower];
                array[lower] = array[higher];
                array[higher] = temp;
                lower++;
                higher--;
            }
        }
    }
}
