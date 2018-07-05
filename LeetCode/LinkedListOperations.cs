using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int value)
        {
            this.val = value;
        }
    }

    public class LinkedListOperations
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slower = head, faster = head;
            bool hasCycle = false;

            while (faster != null)
            {
                if (faster.next == null)
                    return false;

                faster = faster.next.next;
                slower = slower.next;

                if (faster == slower)
                {
                    return true;
                }
            }

            return hasCycle;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode listA = headA, listB = headB;

            if (listA == null || listB == null)
                return null;

            bool flipA = false, flipB = false;
            while (listA.val != listB.val)
            {
                listA = listA.next;
                listB = listB.next;

                if (listA == null)
                {
                    if (!flipA)
                    {
                        listA = headB;
                        flipA = true;
                    }
                    else
                    {
                        return null;
                    }
                }


                if (listB == null)
                {
                    if (!flipB)
                    {
                        listB = headA;
                        flipB = true;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return listA;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null, current = null;
            ListNode current_first = l1, current_second = l2;
            double carry_div = 0;
            int sum = 0;

            while (current_first != null || current_second != null || carry_div != 0.0)
            {
                int first_val = current_first != null ? current_first.val : 0;
                int second_val = current_second != null ? current_second.val : 0;
                sum = first_val + second_val + Convert.ToInt32(carry_div);
                carry_div = Math.Floor((double)sum / 10.0);
                int remainder = sum % 10;

                if (head == null)
                    current = head = new ListNode(remainder);
                else
                {
                    current = AppendList(remainder, current);
                }

                if (current_first != null)
                    current_first = current_first.next;
                if (current_second != null)
                    current_second = current_second.next;
            }

            if (sum == 0)
            {
                return new ListNode(0);
            }

            return head;
        }

        private ListNode AppendList(int number, ListNode current)
        {
            current.next = new ListNode(number);
            current = current.next;
            return current;
        }

        public ListNode CreateNumberList(ulong number)
        {
            ListNode head = null, current = null;

            while (number > 0)
            {
                ulong remainder = number % 10;
                double division = Math.Floor((double)number / 10.0);
                number = Convert.ToUInt64(division);

                if (head == null)
                    current = head = new ListNode((int)remainder);
                else
                {
                    current.next = new ListNode((int)remainder);
                    current = current.next;
                }
            }

            return head;
        }

        public ulong GetNumber(ListNode head)
        {
            ulong multiple = 1;
            ulong sum = 0;

            while (head != null)
            {
                sum += (ulong)head.val * multiple;
                multiple *= 10;
                head = head.next;
            }

            return sum;
        }

        private ListNode ReverseRecursive(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode previous = ReverseRecursive(head.next);
            head.next.next = head;
            head.next = null;
            return previous;
        }

        private ListNode ReverseRecursive(ListNode head, ListNode previous)
        {
            if (head != null)
            {
                ListNode nextNode = head.next;
                head.next = previous;
                return ReverseRecursive(nextNode, head);
            }
            else
            {
                return previous;
            }
        }

        private ListNode ReverseIterative(ListNode head)
        {
            ListNode previousNode = null;
            ListNode currentNode = head;
            ListNode nextNode = head.next;

            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }

            return previousNode;
        }
    }
}
