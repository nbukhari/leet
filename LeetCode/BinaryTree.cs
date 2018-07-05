using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }

    /// <summary>
    /// Binary Search Tree Iterator
    /// next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
    /// Time Complexity
    ///     O(1)
    /// Space Complexity
    ///     O(h)
    /// </summary>
    public class BSTIterator
    {
        private Stack<TreeNode> stack;

        public BSTIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            Push(root);
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return stack.Any();
        }

        /** @return the next smallest number */
        public int Next()
        {
            TreeNode node = stack.Pop();
            Push(node.right);
            return node.val;
        }

        private void Push(TreeNode root)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
        }
    }

    public class BinaryTree
    {
        /// <summary>
        /// Method to find the kth largest no in given BST
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null)
                return -1;

            return KthSmallestUtil(root, ref k);
        }

        // utility function to find kth largest no in 
        // a given tree
        private int KthSmallestUtil(TreeNode root, ref int k)
        {
            if (root == null)
                return -1;

            int result = KthSmallestUtil(root.left, ref k);
            if (result != -1) return result;

            if (--k == 0) return root.val;

            return KthSmallestUtil(root.right, ref k);
        }

        /// <summary>
        /// Method to find the kth largest no in given BST
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        void KthLargest(Node root, int k)
        {
            int c = 0;
            this.KthLargestUtil(root, k, c);
        }

        // utility function to find kth largest no in 
        // a given tree
        private int KthLargestUtil(Node node, int k, int C)
        {
            // Base cases, the second condition is important to
            // avoid unnecessary recursive calls
            if (node == null || C >= k)
                return -1;

            // Follow reverse inorder traversal so that the
            // largest element is visited first
            this.KthLargestUtil(node.right, k, C);

            // Increment count of visited nodes
            // If c becomes k now, then this is the k'th largest 
            if (++C == k)
            {
                return node.val;
            }

            // Recur for left subtree
            this.KthLargestUtil(node.left, k, C);
            return -1;
        }

        /// <summary>
        /// Serialize and Deserialize Binary Tree
        /// Time Complexity
        ///     O(N)
        /// Space Complexity
        ///     O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return "#";
            }

            return root.val + "," + serialize(root.left) + "," + serialize(root.right);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;

            string[] fields = data.Split(',');
            int i = 0;

            TreeNode root = deserialize(fields, ref i);

            return root;
        }

        public TreeNode deserialize(string[] data, ref int i)
        {
            if (data[i] == "#")
            {
                i++;
                return null;
            }

            TreeNode root = new TreeNode(int.Parse(data[i++]));

            if (i < data.Length)
            {
                TreeNode left = deserialize(data, ref i);
                root.left = left;
            }

            if (i < data.Length)
            {
                TreeNode right = deserialize(data, ref i);
                root.right = right;
            }

            return root;
        }

        public TreeNode ConvertArrayToTree(int[] array)
        {
            int i = 1;
            TreeNode head = new TreeNode(array[0]);
            TreeNode current = head;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (i < Math.Log(array.Length))
            {
                current = i > 0 ? new TreeNode(array[i]) : current;
                current.left = new TreeNode(array[2 * i + 1]);
                current.right = new TreeNode(array[2 * i + 2]);
            }

            return head;
        }

        public Node TreeToDoublyList(Node root)
        {
            Node prev = null, head = null;
            TreeToDoublyList(root, ref prev, ref head);
            return head;
        }

        // Understand the solution here: http://cslibrary.stanford.edu/109/TreeListRecursion.html
        private void TreeToDoublyList(Node p, ref Node prev, ref Node head)
        {
            if (p == null) return;

            TreeToDoublyList(p.left, ref prev, ref head);

            // current node's left points to previous node
            p.left = prev;
            if (prev != null)
                prev.right = p;  // previous node's right points to current node
            else
                head = p; // current node (smallest element) is head of
                          // the list if previous node is not available

            // as soon as the recursion ends, the head's left pointer 
            // points to the last node, and the last node's right pointer
            // points to the head pointer.
            Node right = p.right;
            head.left = p;
            p.right = head;

            // updates previous node
            prev = p;
            TreeToDoublyList(right, ref prev, ref head);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0)
                return null;

            int preIndex = 0;
            return BuildTree(preorder, inorder, ref preIndex, 0, preorder.Length - 1);
        }

        private TreeNode BuildTree(int[] preorder, int[] inorder, ref int preIndex, int startIndex, int endIndex)
        {
            // node is null
            if (startIndex > endIndex)
                return null;

            TreeNode current = new TreeNode(preorder[preIndex++]);

            if (startIndex == endIndex)
                return current;

            // search index for in-order
            int inIndex = IndexOf(inorder, startIndex, endIndex, current.val);

            // less than inorder index is left tree
            current.left = BuildTree(preorder, inorder, ref preIndex, startIndex, inIndex - 1);
            // greater than inorder index is rigth tree
            current.right = BuildTree(preorder, inorder, ref preIndex, inIndex + 1, endIndex);
            return current;
        }

        private int IndexOf(int[] inorder, int start, int end, int val)
        {
            for (int i = start; i <= end; i++)
            {
                if (inorder[i] == val)
                {
                    return i;
                }
            }
            return -1;
        }

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            int min = 0;           //To track the left most span of the tree.
            int max = 0;          //To track the right most span of the tree.
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();  //map vertical level -> nodes.
            Queue<int> orderQueue = new Queue<int>();                     //For BFS to track vertical order (left to right)
            Queue<TreeNode> treeNodesQueue = new Queue<TreeNode>();      //For BFS to track tree nodes.
            treeNodesQueue.Enqueue(root);
            orderQueue.Enqueue(0);
            while (treeNodesQueue.Count > 0)
            {
                int order = orderQueue.Dequeue();
                TreeNode node = treeNodesQueue.Dequeue();
                List<int> currList;
                if (!map.TryGetValue(order, out currList))
                {    //Insert the curr node in the list
                    currList = new List<int>();
                    map[order] = currList;
                }
                currList.Add(node.val);
                if (node.left != null)
                {                    //Go to Left
                    treeNodesQueue.Enqueue(node.left);
                    orderQueue.Enqueue(order - 1);
                    min = Math.Min(min, order - 1);
                }
                if (node.right != null)
                {                   //Go to Right
                    treeNodesQueue.Enqueue(node.right);
                    orderQueue.Enqueue(order + 1);
                    max = Math.Max(max, order + 1);
                }
            }
            for (int i = min; i <= max; i++)    //Convert map to result
                res.Add(map[i]);
            return res;
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int maxDepth = 1;
            depth(root, ref maxDepth);
            return maxDepth - 1;
        }

        private int depth(TreeNode current, ref int maxDepth)
        {
            if (current == null)
            {
                return 0;
            }
            int leftMax = depth(current.left, ref maxDepth);
            int rightMax = depth(current.right, ref maxDepth);
            maxDepth = Math.Max(maxDepth, leftMax + rightMax + 1);
            return Math.Max(leftMax, rightMax) + 1;
        }

        /// <summary>
        /// Binary Tree Paths
        /// Given a binary tree, return all root-to-leaf paths.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();

            if (root == null)
                return paths;

            TraverseTree(root, "", paths);

            return paths;
        }

        private void TraverseTree(TreeNode current, string previous, IList<string> paths)
        {
            if (current.left == null && current.right == null)
            {
                paths.Add(previous + current.val);
                return;
            }
            if (current.left != null) TraverseTree(current.left, previous + $"{current.val}->", paths);
            if (current.right != null) TraverseTree(current.right, previous + $"{current.val}->", paths);
        }

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsValidBST(TreeNode current, int min, int max)
        {
            if (current == null)
                return true;

            if ((current.left != null && current.left.val >= current.val) ||
                (current.right != null && current.right.val <= current.val))
                return false;

            if (current.val < min || current.val > max)
                return false;

            return (IsValidBST(current.left, min, current.val - 1) &&
                IsValidBST(current.right, current.val + 1, max));
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if ((p == null && q == null))
                return true;

            if ((p == null && q != null) || (p != null && q == null) || p.val != q.val)
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        /// <summary>
        /// Flatten by joining right tree subtree to right leave of left subtree
        /// </summary>
        /// <param name="root"></param>
        public void FlattenByJoining(TreeNode root)
        {
            TreeNode current = root, previous = root;

            while (current != null)
            {
                if (current.left != null)
                {
                    previous = current.left;

                    while (previous.right != null)
                    {
                        previous = previous.right;
                    }

                    previous.right = current.right;
                    current.right = current.left;
                    current.left = null;
                }
                current = current.right;
            }
        }

        /// <summary>
        /// Morris In-Order Traversal Flattern
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            TreeNode current = root, previous = root;

            while (current != null)
            {
                if (current.left != null)
                {
                    previous = current.left;

                    while (previous.right != null && previous.right != current)
                    {
                        previous = previous.right;
                    }

                    if (previous.right == null)
                    {
                        previous.right = current;
                        current = current.left;
                    }
                    else
                    {
                        TreeNode right = current.right;
                        current.right = current.left;
                        current.left = null;
                        previous.right = right;
                        current = right;
                    }
                }
                else
                {
                    current = current.right;
                }
            }
        }
    }
}
