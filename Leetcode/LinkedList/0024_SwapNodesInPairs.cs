using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class SwapNodesInPairs_0024
    {
        public static ListNode? SwapPairs(ListNode? head)
        {
            ListNode? node = head;
            ListNode? prev = null;
            while (node != null && node.next != null)
            {
                ListNode? next = node.next;

                node.next = next.next;
                next.next = node;
                if (prev == null)
                    head = next;
                else
                    prev.next = next;

                prev = next.next;
                node = node.next;
            }
            return head;
        }



        public static void Check()
        {
            var test1 = new TestData_0024()
            {
                Input = new int[] { 1, 2, 15, 3, 4, 1, 2, 15, 3, 4 },
                Output = new int[] { 2, 1, 3, 15, 1, 4, 15, 2, 4, 3 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_0024()
            {
                Input = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_0024()
            {
                Input = new int[] { 1 },
                Output = new int[] { 1 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_0024()
            {
                Input = new int[] { 1, 2, 15, 3, 4 },
                Output = new int[] { 2, 1, 3, 15, 4 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_0024 data)
        {
            ListNode? node = ListNode.Factory(data.Input, 0);
            ListNode? res = SwapPairs(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_0024
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
