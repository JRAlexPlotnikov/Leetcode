using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class MiddleOfTheLinkedList_876
    {
        public static ListNode? MiddleNode(ListNode? head)
        {
            ListNode? temp = head;
            byte count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            byte stop = (byte)(count / 2 + 1);
            count = 0;
            while (head != null)
            {
                count++;
                if (count == stop)
                {
                    break;
                }
                head = head.next;
            }
            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_876()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Output = new int[] { 3, 4, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_876()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6 },
                Output = new int[] { 4, 5, 6 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");
        }

        private static bool CheckResult(TestData_876 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res = MiddleNode(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_876
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
