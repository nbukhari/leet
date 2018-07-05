using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /**
     * // This is the interface that allows for creating nested lists.
     * // You should not implement it, or speculate about its implementation
     * interface NestedInteger {
     *
     *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
     *     bool IsInteger();
     *
     *     // @return the single integer that this NestedInteger holds, if it holds a single integer
     *     // Return null if this NestedInteger holds a nested list
     *     int GetInteger();
     *
     *     // @return the nested list that this NestedInteger holds, if it holds a nested list
     *     // Return null if this NestedInteger holds a single integer
     *     IList<NestedInteger> GetList();
     * }
     */

    public interface NestedInteger
    {
    
         // @return true if this NestedInteger holds a single integer, rather than a nested list.
         bool IsInteger();
    
         // @return the single integer that this NestedInteger holds, if it holds a single integer
         // Return null if this NestedInteger holds a nested list
         int GetInteger();
    
         // @return the nested list that this NestedInteger holds, if it holds a nested list
         // Return null if this NestedInteger holds a single integer
         IList<NestedInteger> GetList();
     }

    public class NestedIterator
    {
        Stack<NestedInteger> stack = new Stack<NestedInteger>();

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            if (nestedList == null)
                return;

            for (int i = nestedList.Count - 1; i >= 0; i--)
            {
                stack.Push(nestedList[i]);
            }
        }

        public bool HasNext()
        {
            while (stack.Any())
            {
                NestedInteger top = stack.Peek();
                if (top.IsInteger())
                {
                    return true;
                }
                else
                {
                    stack.Pop();
                    for (int i = top.GetList().Count - 1; i >= 0; i--)
                    {
                        stack.Push(top.GetList()[i]);
                    }
                }
            }

            return false;
        }

        public int Next()
        {
            return stack.Pop().GetInteger();
        }
    }

    public class IteratorOperations
    {
    }
}
