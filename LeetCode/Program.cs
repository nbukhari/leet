using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxDifference();
            Console.ReadKey();
        }

        private static void MergeSort()
        {
            int[] number = new int[10] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 };
            SortingAlgortihms solution = new SortingAlgortihms();
            solution.MergeSort(ref number);
            PrintArrayOfInts(number);
        }

        private static void SearchRoatedDuplicate()
        {
            int[] arr = { 1, 3, 1, 1, 1 };
            int target = 3;
            SortNSearch sortNSearch = new SortNSearch();
            Console.WriteLine(sortNSearch.SearchRoatedDuplicate(arr, target));
        }

        private static void SearchRotated()
        {
            int[] arr = { 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            int target = 6;
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.SearchRotated(arr, target);
        }

        private static void MergeTwoLists()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.MergeTwoLists(l1, l2);
        }

        private static void MergeSortedArrays()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = new int[] { 2, 5, 6 };
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.MergeSortedArrays(nums1, 3, nums2, 3);
        }

        private static void MinMeetingRooms()
        {
            var intervals = new List<Interval>() { new Interval(5, 10), new Interval(0, 30), new Interval(15, 20) };
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.MinMeetingRooms(intervals.ToArray());
        }

        private static void CanAttendMeetings()
        {
            var intervals = new List<Interval>() { new Interval(5, 10), new Interval(0, 30), new Interval(15, 20) };
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.CanAttendMeetings(intervals.ToArray());
        }

        private static void MergeIntervals()
        {
            var intervals = new List<Interval>() { new Interval(1, 4), new Interval(0, 4) };
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.MergeIntervals(intervals);
        }

        private static void FirstBadVersion()
        {
            int n = 4;
            SortNSearch sortNSearch = new SortNSearch();
            sortNSearch.FirstBadVersion(n);
        }

        private static void IsMatch()
        {
            string s = "mississippi";
            string p = "m??*ss*?i*pi";
            BackTrackingOperations backTrackingOperations = new BackTrackingOperations();
            backTrackingOperations.IsMatch(s, p);
        }

        private static void RemoveInvalidParentheses()
        {
            string parantheses = "()())()";
            BackTrackingOperations backTrackingOperations = new BackTrackingOperations();
            backTrackingOperations.RemoveInvalidParentheses(parantheses);
        }

        private static void Subsets()
        {
            BackTrackingOperations backTrackingOperations = new BackTrackingOperations();
            backTrackingOperations.Subsets(new int[] { 1, 2, 3, 4});
        }

        private static void LetterCombination()
        {
            BackTrackingOperations backTrackingOperations = new BackTrackingOperations();
            backTrackingOperations.LetterCombinations("23");
        }

        private static void NumIslands()
        {
            char[,] grid = new char[,] {
                { '1', '1', '0', '0', '0' },
                {'1', '1', '0', '0', '0' },
                {'0', '0', '1', '0', '0' },
                {'0', '0', '0', '1', '1' }
            };
            GraphOperations graph = new GraphOperations();
            Console.WriteLine(graph.NumIslands(grid));
        }

        private static void SerializeTree()
        {
            TreeNode root = new TreeNode(4, null, null);
            root.left = new TreeNode(2, new TreeNode(1, null, null), new TreeNode(3, null, null));
            root.right = new TreeNode(5, null, null);

            BinaryTree binaryTree = new BinaryTree();
            Console.WriteLine(binaryTree.serialize(root));
        }


        private static void TreeToDoublyList()
        {
            Node root = new Node(4, null, null);
            root.left = new Node(2, new Node(1, null, null), new Node(3, null, null));
            root.right = new Node(5, null, null);

            string json = "{\"$id\":\"1\",\"left\":{\"$id\":\"2\",\"left\":null,\"right\":{\"$id\":\"3\",\"left\":{\"$id\":\"4\",\"left\":{\"$id\":\"5\",\"left\":{\"$id\":\"6\",\"left\":{\"$id\":\"7\",\"left\":null,\"right\":null,\"val\":-69},\"right\":{\"$id\":\"8\",\"left\":{\"$id\":\"9\",\"left\":{\"$id\":\"10\",\"left\":null,\"right\":{\"$id\":\"11\",\"left\":null,\"right\":null,\"val\":-36},\"val\":-39},\"right\":null,\"val\":-30},\"right\":null,\"val\":-20},\"val\":-60},\"right\":null,\"val\":-18},\"right\":{\"$id\":\"12\",\"left\":{\"$id\":\"13\",\"left\":{\"$id\":\"14\",\"left\":null,\"right\":{\"$id\":\"15\",\"left\":null,\"right\":{\"$id\":\"16\",\"left\":null,\"right\":null,\"val\":14},\"val\":6},\"val\":-2},\"right\":{\"$id\":\"17\",\"left\":{\"$id\":\"18\",\"left\":null,\"right\":null,\"val\":40},\"right\":null,\"val\":42},\"val\":18},\"right\":{\"$id\":\"19\",\"left\":{\"$id\":\"20\",\"left\":null,\"right\":null,\"val\":54},\"right\":null,\"val\":55},\"val\":51},\"val\":-11},\"right\":{\"$id\":\"21\",\"left\":null,\"right\":null,\"val\":68},\"val\":66},\"val\":-86},\"right\":{\"$id\":\"22\",\"left\":null,\"right\":null,\"val\":98},\"val\":90}";
            root = Serializer.Deserialize<Node>(json);

            BinaryTree binaryTree = new BinaryTree();
            binaryTree.TreeToDoublyList(root);
        }

        private static void GetIntersectionNode()
        {
            LinkedListOperations linkedList = new LinkedListOperations();

            ListNode firstNumber = linkedList.CreateNumberList(3);
            ListNode secondNumber = linkedList.CreateNumberList(32);

            ListNode sum = linkedList.GetIntersectionNode(firstNumber, secondNumber);
            Console.WriteLine($"Sum : {linkedList.GetNumber(sum)}");
        }

        private static void AddNumbers()
        {
            LinkedListOperations linkedList = new LinkedListOperations();

            ListNode firstNumber = linkedList.CreateNumberList(9);
            ListNode secondNumber = linkedList.CreateNumberList(9999999991);

            ListNode sum = linkedList.AddTwoNumbers(firstNumber, secondNumber);
            Console.WriteLine($"Sum : {linkedList.GetNumber(sum)}");
        }

        private static void RomanToInt()
        {
            string number = "MCDLXXVI";
            StringOperations stringOperations = new StringOperations();
            Console.Write(stringOperations.RomanToInt(number));
        }

        private static void IsValidParanthese()
        {
            string parantheses = "()[]{}";
            StringOperations stringOperations = new StringOperations();
            Console.Write(stringOperations.IsValidParanthese(parantheses));
        }

        private static void MinSubArrayLen()
        {
            int[] number = new int[] { 2, 3, 1, 2, 4, 3 };
            ArrayOperations solution = new ArrayOperations();
            Console.WriteLine(solution.MinSubArrayLen(7, number));
        }

        private static void IsValidNumber()
        {
            string number = "2e0";
            StringOperations stringOperations = new StringOperations();
            Console.Write(stringOperations.IsValidNumber(number));
        }

        private static void Palindrome()
        {
            string test = "A man, a plan, a canal: Panama";
            test = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";
            StringOperations stringOperations = new StringOperations();
            Console.WriteLine(stringOperations.ValidPalindrome(test));
        }

        private static void MinDifference()
        {
            int[] number = new int[] { 4, 2, 4, 0, 0, 0, 3, 5, 1, 50 };
            number = new int[] { -50, 10, 5, 4, 3, 2, 1, 0 };
            ArrayOperations solution = new ArrayOperations();
            Console.WriteLine(solution.MinDifference(number));
        }

        private static void MaxDifference()
        {
            int[] number = new int[] { 4, 2, 4, 0, 0, 0, 3, 5, 1, 50 };
            number = new int[] { -50, 10, 5, 4, 3, 2, 1, 0 };
            ArrayOperations solution = new ArrayOperations();
            Console.WriteLine(solution.MaxDifferenceWithSum(number));
        }

        private static void ThreeSums()
        {
            int[] number = new int[10] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 };
            ArrayOperations solution = new ArrayOperations();
            solution.ThreeSum(number);
            PrintArrayOfInts(number);
        }
        
        public static void ProductExceptSelf()
        {
            ArrayOperations arrayOperations = new ArrayOperations();
            int[] result = arrayOperations.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            PrintArrayOfInts(result);
        }

        public static void IntersectionOfTwoArrays()
        {
            ArrayOperations arrayOperations = new ArrayOperations();
            int[] result = arrayOperations.Intersect( new int[] { -2147483648, 1, 2, 3 }, 
                new int[] { 1, -2147483648, -2147483648 });
            PrintArrayOfInts(result);
        }

        private static void AddBinary()
        {
            string binary_1 = "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101";
            string binary_2 = "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011";
            BinaryStrings binaryStrings = new BinaryStrings();
            string result = binaryStrings.AddBinary(binary_1, binary_2);
            Console.WriteLine($"Output: {result}");
        }

        private static void Sqrt()
        {
            int number = 1024;
            NumberOperaions numberOperaions = new NumberOperaions();
            Console.WriteLine(numberOperaions.MySqrt(number));
        }

        private static void MoveZeroesToEnds()
        {
            int[] number = new int[10] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 };
            MovingZeros solution = new MovingZeros();
            solution.MoveZeroesToEnds(number);
            PrintArrayOfInts(number);
        }

        private static void MoveZeros()
        {
            int[] number = new int[10] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 };
            MovingZeros solution = new MovingZeros();
            solution.MoveZeroes(number);
            PrintArrayOfInts(number);
        }

        private static void PrintArrayOfInts(int[] results)
        {
            Console.Write("[");
            foreach (int num in results)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine("]");
        }
    }
}
