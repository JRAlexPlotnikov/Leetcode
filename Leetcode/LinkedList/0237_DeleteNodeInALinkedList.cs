using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class DeleteNodeInALinkedList_237
    {
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        public static void Check()
        {
            var test1 = new TestData_237()
            {
                Input = new int[] { 4, 5, 1, 9 },
                k = 5,
                Output = new int[] { 4, 1, 9 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_237()
            {
                Input = new int[] { 4, 5, 1, 9 },
                k = 1,
                Output = new int[] { 4, 5, 9 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

        }

        private static bool CheckResult(TestData_237 data)
        {
            ListNode? head = ListNode.Factory(data.Input, 0);
            ListNode? node = head;
            while (node != null)
            {
                if (node.val == data.k)
                {
                    DeleteNode(node);
                    break;
                }
                node = node.next;
            }
            return ListNode.Compary(head, data.Output);
        }
    }

    internal class TestData_237
    {
        public int[]? Input { get; set; }
        public int k { get; set; }
        public int[]? Output { get; set; }
    }
}
