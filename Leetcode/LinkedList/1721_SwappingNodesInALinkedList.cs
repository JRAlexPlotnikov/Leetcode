using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class SwappingNodesInALinkedList_1721
    {
        public static ListNode? SwapNodes(ListNode? head, int k)
        {
            if (head == null || head.next == null)
                return head;

            int length = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            k = (length - k >= k) ? k : length - k + 1;

            temp = head;
            ListNode? first = null;
            ListNode? last = null;
            int i = 0;
            while (temp != null)
            {
                i++;
                if (i == k - 1)
                    first = temp;

                if (i == length - k)
                    last = temp;

                temp = temp.next; 
            }

            ListNode? tails = first.next.next;
            last.next = first.next;
            last.next = null;



            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_1721()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                K = 2,
                Output = new int[] { 1, 4, 3, 2, 5 },
            };
            if (!CheckResult(test1))
                throw new Exception("Error test");

            var test2 = new TestData_1721()
            {
                Input = new int[] { 7, 9, 6, 6, 7, 8, 3, 0, 9, 5 },
                K = 3,
                Output = new int[] { 7, 9, 0, 6, 7, 8, 3, 6, 9, 5 },
            };
            if (!CheckResult(test2))
                throw new Exception("Error test");

            var test3 = new TestData_1721()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                K = 4,
                Output = new int[] { 1, 4, 3, 2, 5 },
            };
            if (!CheckResult(test3))
                throw new Exception("Error test");

            var test4 = new TestData_1721()
            {
                Input = new int[] { 1 },
                K = 1,
                Output = new int[] { 1 },
            };
            if (!CheckResult(test4))
                throw new Exception("Error test");

            var test5 = new TestData_1721()
            {
                Input = new int[] { 1, 2 },
                K = 1,
                Output = new int[] { 2, 1 },
            };
            if (!CheckResult(test5))
                throw new Exception("Error test");

            var test6 = new TestData_1721()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                K = 12,
                Output = new int[] { 12, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 1 },
            };
            if (!CheckResult(test6))
                throw new Exception("Error test");

            var test7 = new TestData_1721()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                K = 1,
                Output = new int[] { 12, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 1 },
            };
            if (!CheckResult(test7))
                throw new Exception("Error test");

            var test8 = new TestData_1721()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                K = 3,
                Output = new int[] { 1, 2, 10, 4, 5, 6, 7, 8, 9, 3, 11, 12 },
            };
            if (!CheckResult(test8))
                throw new Exception("Error test");
        }

        private static bool CheckResult(TestData_1721 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input);
            ListNode? head = SwapNodes(test1input1, data.K);
            return ListNode.Compary(head, data.Output);
        }
    }

    internal class TestData_1721
    {
        public int[]? Input { get; set; }
        public int K { get; set; }
        public int[]? Output { get; set; }
    }
}
