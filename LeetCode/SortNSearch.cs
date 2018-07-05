using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Interval {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class SortNSearch
    {
        /// <summary>
        /// Use sorted set min max to find current range. Terminate as soon as one of the list is exhausted. This is
        /// optimal because the last element of the exhausted list is the smallest value (`x`) in queue. So the
        /// range was [x, y], y is from some other list. If we were to keep x but enumerate any other list, the range 
        /// will become [x, z] where z >= y, which is not optimal than [x,y].
        /// 
        /// Also note since the ranges are enumerated from small to large, when U-L == u-l, we don't need to update (L,U),
        /// since l >= u.
        /// https://leetcode.com/articles/smallest-range/
        /// Time Complexity
        ///     O(nlogk) for heapification
        ///     Heapification of k elements requires O(log(k)) time. This step could be done for all the elements of the 
        ///     given lists in the worst case. Here, n refers to the total number of elements in all the lists. k refers 
        ///     to the total number of lists.
        ///     O(n) for traversal
        /// Space Complexity
        ///     O(k)
        ///     A Min-Heap with k elements is used.
        ///     
        /// Note: This solution will not work in case of duplicates as SortedSet doesn't support duplicates
        /// </summary>
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            int n = nums.Count;
            // Heap with tuple (Value, Index, Row)
            var q = new SortedSet<(int V, int I, int R)>();
            for (int i = 0; i < n; i++)
                if (nums[i].Count > 0)
                    q.Add((nums[i][0], 0, i));
            var (L, U) = (0, -1);

            while (q.Count == n)
            {
                var (l, u) = (q.Min.V, q.Max.V);

                if (L > U || U - L > u - l)
                    (L, U) = (l, u);

                var (v, i, r) = q.Min;
                q.Remove((v, i, r));

                if (i + 1 < nums[r].Count)
                    q.Add((nums[r][i + 1], i + 1, r));
            }

            return new[] { L, U };
        }

        /// <summary>
        /// Merge Interval solution with inplace sort
        /// Time Complexity
        ///     O(nlgn) for sorting
        ///     O(n) for traversal
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public IList<Interval> MergeIntervals(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count < 2)
                return intervals;

            IList<Interval> results = new List<Interval>();

            intervals = intervals.OrderBy(n => n.start).ToList();

            foreach (Interval interval in intervals)
            {
                // if the list of merged intervals is empty or if the current
                // interval does not overlap with the previous, simply append it.
                if (!results.Any() || results.Last().end < interval.start)
                {
                    results.Add(interval);
                }
                // otherwise, there is overlap, so we merge the current and previous
                // intervals.
                else
                {
                    results.Last().end = Math.Max(results.Last().end, interval.end);
                }
            }

            return results;
        }

        /// <summary>
        /// Merge Interval solution with separate start and end
        /// Time Complexity
        ///     O(nlgn) for sorting
        ///     O(n) for traversal
        /// Space Complexity
        ///     O(n)
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public IList<Interval> MergeInterval(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count < 2)
                return intervals;

            // sort start&end
            int n = intervals.Count;
            int[] starts = new int[n];
            int[] ends = new int[n];

            for (int i = 0; i < n; i++)
            {
                starts[i] = intervals[i].start;
                ends[i] = intervals[i].end;
            }

            Array.Sort(starts);
            Array.Sort(ends);

            // loop through
            List<Interval> res = new List<Interval>();
            for (int i = 0, j = 0; i < n; i++)
            { // j is start of interval.
                if (i == n - 1 || starts[i + 1] > ends[i])
                {
                    res.Add(new Interval(starts[j], ends[i]));
                    j = i + 1;
                }
            }

            return res;
        }

        /// <summary>
        /// Search an element in rotated array with duplicatess
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchRoatedDuplicate(int[] nums, int target)
        {
            return Search(nums, nums.Length, target);
        }
        
        /// <summary>
        /// We will perform binary search unless we get into duplicate values
        /// if so, we will switch to linear search
        /// Time Complexity
        ///     O(lgn) if no duplicates
        ///     O(n) if duplicates
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int Search(int[] nums, int n, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;

                if (nums[left] < nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[left] > nums[mid])
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left++;
                }
            }

            return -1;
        }

        /// <summary>
        /// Search element in rotated array with distant values
        /// Time Complexity
        ///     O(lgn) if no duplicates
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchRotated(int[] nums, int target)
        {
            return SearchIterative(nums, target);
            // return SearchRecursive(nums, 0, nums.Length-1, target);
        }

        public int SearchIterative(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            // Binary Search
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (target == nums[mid])
                    return mid;

                /* If nums[l...mid] is sorted */
                if (nums[left] <= nums[mid])
                {
                    /* As this subarray is sorted, we can quickly
                    check if key lies in half or other half */
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    /* If arr[l..mid] is not sorted, then arr[mid... r]
                    must be sorted*/
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }

        // Returns index of key in arr[l..h] if 
        // key is present, otherwise returns -1
        int SearchRecursive(int[] arr, int l, int h, int key)
        {
            if (l > h) return -1;

            int mid = (l + h) / 2;
            if (arr[mid] == key) return mid;

            /* If arr[l...mid] is sorted */
            if (arr[l] <= arr[mid])
            {
                /* As this subarray is sorted, we can quickly
                check if key lies in half or other half */
                if (key >= arr[l] && key <= arr[mid])
                    return SearchRecursive(arr, l, mid - 1, key);

                return SearchRecursive(arr, mid + 1, h, key);
            }

            /* If arr[l..mid] is not sorted, then arr[mid... r]
            must be sorted*/
            if (key >= arr[mid] && key <= arr[h])
                return SearchRecursive(arr, mid + 1, h, key);

            return SearchRecursive(arr, l, mid - 1, key);
        }

        /// <summary>
        /// Merge K Lists with Divide And Conquer
        /// Time Complexity
        ///     O(Nlgk)
        /// Space Complexity
        ///     O(1)
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        /// https://leetcode.com/articles/merge-k-sorted-list/
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            else if (lists.Length == 1)
            {
                return lists[0];
            }
            else
            {
                for (int steps = 1; steps < lists.Length; steps = steps * 2)
                {
                    for (int i = 0; i < lists.Length; i = i + 2 * steps)
                    {
                        if (i + steps >= lists.Length)
                        {
                            continue;
                        }
                        else
                        {
                            lists[i] = MergeTwoLists(lists[i], lists[i + steps]);
                        }
                    }
                }
                return lists[0];
            }
        }

        public ListNode MergeTwoLists(ListNode left, ListNode right)
        {
            /* a dummy first node to hang the result on */
            ListNode result = new ListNode(0);
            result.next = null;
            /* tail points to the last result node  */
            ListNode current = result;

            while (true)
            {
                /* if either list runs out, use the
                   other list */
                if (left == null)
                {
                    current.next = right;
                    break;
                }
                else if (right == null)
                {
                    current.next = left;
                    break;
                }

                if (left.val > right.val)
                {
                    current.next = right;
                    right = right.next;
                }
                else
                {
                    current.next = left;
                    left = left.next;
                }

                current = current.next;
            }

            return result.next;
        }

        /// <summary>
        /// Merge Sorted Arrays
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int idx = m + n - 1;
            m--;
            n--;
            while (n >= 0)
            {
                if (m >= 0 && nums1[m] > nums2[n])
                {
                    nums1[idx--] = nums1[m--];
                }
                else
                {
                    nums1[idx--] = nums2[n--];
                }
            }
        }

        /// <summary>
        /// Minimum Meeting Rooms Required
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms(Interval[] intervals)
        {
            // As c# doesn't have MinHeap so we will do it with extra memory
            if (null == intervals) return 0;
            if (intervals.Length <= 1) return intervals.Length;

            int[] startTimes = new int[intervals.Length];
            int[] endTimes = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                Interval curr = intervals[i];
                startTimes[i] = curr.start;
                endTimes[i] = curr.end;
            }
            Array.Sort(startTimes);
            Array.Sort(endTimes);

            int minMeetingRooms = 0;
            int endTimesIterator = 0;
            for (int i = 0; i < startTimes.Length; i++)
            {
                minMeetingRooms++;       //Increment the room for the current meeting that is starting.
                                         //Check if startTime of current meeting is after endTime of meeting that is suppose to end first.
                if (startTimes[i] >= endTimes[endTimesIterator])
                {
                    minMeetingRooms--;   //since one meeting ended, a room got empty.
                    endTimesIterator++;  //move to the next endTime.
                }
            }
            return minMeetingRooms;
        }

        /// <summary>
        /// Minimum Meeting Rooms Required
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRoomsTimelineBased(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            int min = int.MaxValue, max = int.MinValue;

            foreach (var intr in intervals)
            {
                if (intr.start < min)
                {
                    min = intr.start;
                }
                if (intr.end > max)
                {
                    max = intr.end;
                }
            }

            int[] timeline = new int[max - min + 1];

            foreach (var intr in intervals)
            {
                timeline[intr.start - min] += 1;
                timeline[intr.end - min] -= 1;
            }

            int activeMeetings = 0;
            int mostAsync = 0;
            foreach (int time in timeline)
            {
                activeMeetings += time;
                if (activeMeetings > mostAsync)
                {
                    mostAsync = activeMeetings;
                }
            }

            return mostAsync;
        }

        /// <summary>
        /// Meeting : Check if a person can attent all meetings
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public bool CanAttendMeetings(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return true;

            intervals = intervals.OrderBy(n => n.start).ToArray();
            // Array.Sort(intervals, CompareIntervals);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i].start < intervals[i - 1].end)
                    return false;
            }

            return true;
        }

        private static int CompareIntervals(Interval a, Interval b)
        {
            return a.start - b.start;
        }

        /// <summary>
        /// Finding the bad version using binary search
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int start = 1, end = n;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (!IsBadVersion(mid))
                    start = mid + 1;
                else
                    end = mid;
            }
            return start;
        }

        private bool IsBadVersion(int version)
        {
            return version >= 3;
        }
    }
}
