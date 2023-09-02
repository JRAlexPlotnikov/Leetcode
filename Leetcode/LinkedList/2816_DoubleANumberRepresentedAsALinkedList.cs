using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class DoubleANumberRepresentedAsALinkedList_2816
    {
        public static ListNode? DoubleIt(ListNode? head)
        {
            int count = 0;
            ListNode? node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }

            int index = 1;
            var arr = new int[count + 1];
            while (head != null)
            {
                arr[index] = head.val;
                index++;
                head = head.next;
            }


            index = 0;
            for (int i = count; i >= 0; i--)
            {
                int val = arr[i] * 2;
                arr[i] = val % 10 + index;
                index = val / 10;
            }

            index = arr[0] == 0 ? 1 : 0;

            return Factory(arr, index, count);
        }

        public static ListNode? Factory(int[]? arr, int index = 0, int stop = 0)
        {
            ListNode? node = null;
            if (arr != null && stop >= index)
                node = new ListNode(arr[index], Factory(arr, (index + 1), stop));
            return node;
        }

        public static void Check()
        {
            var test1 = new TestData_2816()
            {
                Input = new int[] { 1, 8, 9 },
                Output = new int[] { 3, 7, 8 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_2816()
            {
                Input = new int[] { 9, 9, 9 },
                Output = new int[] { 1, 9, 9, 8 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_2816()
            {
                Input = new int[] { 1 },
                Output = new int[] { 2 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_2816()
            {
                Input = new int[] { 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5 },
                Output = new int[] { 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_2816 data)
        {
            ListNode? node = ListNode.Factory(data.Input, 0);
            ListNode? res = DoubleIt(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_2816
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
