using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class RemoveLinkedListElements_203
    {
        public static ListNode? RemoveElements(ListNode? head, int val)
        {
            ListNode? result = null;
            while (head != null && head.val == val)
                head = head.next;
            if (head != null)
                result = new ListNode(head.val, RemoveElements(head.next, val));

            return result;
        }

        public static void Check()
        {
            var test1 = new TestData_203()
            {
                Input = new int[] { 1, 2, 6, 3, 4, 5, 6 },
                Val = 6,
                Output = new int[] { 1, 2, 3, 4, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_203()
            {
                Input = Array.Empty<int>(),
                Val = 1,
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_203()
            {
                Input = new int[] { 7, 7, 7, 7 },
                Val = 7,
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_203 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res1 = RemoveElements(node, data.Val);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_203
    {
        public int[]? Input { get; set; }
        public int Val { get; set; }
        public int[]? Output { get; set; }
    }
}
