using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class PalindromeLinkedList_234
    {
        /*public static bool IsPalindrome(ListNode? head)
        {
            ListNode? last;
            while (head != null && head.next != null)
            {
                last = head;
                while (last?.next?.next != null) {
                    last = last.next;
                }

                if (last?.next?.val != head.val)
                    return false;

                head = head.next;
                if (last != null)
                    last.next = null;
            }

            return true;
        }*/

        public static bool IsPalindrome(ListNode? head)
        {
            int length = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            int[] vals = new int[length];
            temp = head;
            int i = 0;
            while (temp != null)
            {
                vals[i] = temp.val;
                i++;
                temp = temp.next;
            }

            i = length - 1;
            while (head != null && head.next != null)
            {
                if (vals[i] != head.val)
                    return false;
                i--;
                head = head.next;
            }

            return true;
        }

        public static void Check()
        {
            var test1 = new TestData_234()
            {
                Input = new int[] { 1, 2, 3, 4, 3, 2, 1 },
                Output = true
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_234()
            {
                Input = new int[] { 1 },
                Output = true
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_234()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Output = false
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_234 data)
        {
            ListNode? head = ListNode.Factory(data.Input, 0);
            bool res = IsPalindrome(head);
            return res == data.Output;
        }
    }

    internal class TestData_234
    {
        public int[]? Input { get; set; }
        public bool Output { get; set; }
    }
}
