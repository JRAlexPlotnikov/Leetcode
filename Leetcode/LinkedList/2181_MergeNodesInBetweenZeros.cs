using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class MergeNodesInBetweenZeros_2181
    {
        public static ListNode? MergeNodes(ListNode? head)
        {
            ListNode? result = null;
            int sum = 0;
            head = head?.next;
            while (head != null)
            {    
                if (head.val == 0)
                {
                    result = new ListNode(sum, MergeNodes(head));
                    break;
                }
                sum += head.val;

                head = head.next;  
            }
            return result;
        }

        public static void Check()
        {
            var test1 = new TestData_2181()
            {
                Input = new int[] { 0, 3, 1, 0, 4, 5, 2, 0 },
                Output = new int[] { 4, 11 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_2181()
            {
                Input = new int[] { 0, 1, 0, 3, 0, 2, 2, 0 },
                Output = new int[] { 1, 3, 4 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            /*var test3 = new TestData_2181()
            {
                Input = new int[] { 1 },
                Output = new int[] { 2 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_2181()
            {
                Input = new int[] { 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5, 1, 8, 2, 3, 4, 5, 9, 9, 1, 2, 4, 5 },
                Output = new int[] { 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0, 3, 6, 4, 6, 9, 1, 9, 8, 2, 4, 9, 0 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");*/
        }

        private static bool CheckResult(TestData_2181 data)
        {
            ListNode? node = ListNode.Factory(data.Input, 0);
            ListNode? res = MergeNodes(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_2181
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
