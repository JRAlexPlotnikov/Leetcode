using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class DeleteTheMiddleNodeOfALinkedList_2095
    {
        public static ListNode? DeleteMiddle(ListNode? head)
        {
            int length = 0;
            ListNode? node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }

            if (length == 1)
                return null;

            int k = length / 2;

            node = head;
            int i = 0;
            while (node != null)
            {
                if (i == k - 1)
                {
                    node.next = node.next.next;
                    break;
                }
                i++;
                node = node.next;
            }

            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_2095()
            {
                Input = new int[] { 1, 3, 4, 7, 1, 2, 6 },
                Output = new int[] { 1, 3, 4, 1, 2, 6 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_2095()
            {
                Input = new int[] { 1, 2, 3, 4 },
                Output = new int[] { 1, 2, 4 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_2095()
            {
                Input = new int[] { 1 },
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_2095()
            {
                Input = new int[] { 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5 },
                Output = new int[] { 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");

            var test5 = new TestData_2095()
            {
                Input = new int[] { 1, 2 },
                Output = new int[] { 1 }
            };
            if (!CheckResult(test5))
                throw new Exception("Error test 5");
        }

        private static bool CheckResult(TestData_2095 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res = DeleteMiddle(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_2095
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
