using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class ReverseLinkedList_206
    {
        public static ListNode? ReverseList(ListNode? head)
        {
            ListNode? temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            int[] list = new int[count];
            count = 0;
            while (head != null)
            {
                list[count] = head.val;
                count++;
                head = head.next;
            }
            return Init(list, list.Count() - 1);
        }

        private static ListNode? Init(int[] list, int index)
        {
            ListNode? head = null;
            if (index >= 0)
            {
                head = new ListNode(list[index], Init(list, index - 1));
            }
            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_206()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Output = new int[] { 5, 4, 3, 2, 1 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_206()
            {
                Input = new int[] { 1, 2 },
                Output = new int[] { 2, 1 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_206()
            {
                Input = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_206 data)
        {
            ListNode? node = ListNode.Factory(data.Input, 0);
            ListNode? res = ReverseList(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_206
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
