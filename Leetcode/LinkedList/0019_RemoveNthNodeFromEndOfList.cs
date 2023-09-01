using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class RemoveNthNodeFromEndOfList_19
    {
        public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
        {
            int length = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            n = length - n;

            return RemoveNthFromStart(head, n, 0);
        }

        private static ListNode? RemoveNthFromStart(ListNode? head, int n, int index)
        {
            ListNode? temp = null;
            if (head != null && n == index)
                head = head.next;

            if (head != null)
            {
                temp = new ListNode(head.val, RemoveNthFromStart(head.next, n, (index + 1)));
            }
            return temp;
        }

        public static void Check()
        {
            var test1 = new TestData_19()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                N = 2,
                Output = new int[] { 1, 2, 3, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_19()
            {
                Input = new int[] { 1 },
                N = 1,
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_19()
            {
                Input = new int[] { 1, 2 },
                N = 1,
                Output = new int[] { 1 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_19 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res1 = RemoveNthFromEnd(node, data.N);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_19
    {
        public int[]? Input { get; set; }
        public int N { get; set; }
        public int[]? Output { get; set; }
    }
}
