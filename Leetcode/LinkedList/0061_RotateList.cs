using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class RotateList_0061
    {
        public static ListNode? RotateRight(ListNode? head, int k)
        {
            if (head == null)
                return null;

            ListNode? temp = head;
            byte count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            k %= count;


            ListNode? node = head;
            while (node.next != null)
                node = node.next;
            node.next = head;

            int j = 0;
            while (j < (count - 1) * k)
            {
                node = node.next;
                j++;
            }
            head = node.next;
            j = 0;
            while (j < count)
            {
                node = node.next;
                j++;
            }
            node.next = null;

            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_61()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Val = 2,
                Output = new int[] { 4, 5, 1, 2, 3 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_61()
            {
                Input = new int[] { 0, 1, 2 },
                Val = 4,
                Output = new int[] { 2, 0, 1 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_61()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 20 },
                Val = 1000,
                Output = new int[] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 20, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_61()
            {
                Input = new int[] { 0, 1, 2 },
                Val = 0,
                Output = new int[] { 0, 1, 2 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");

            var test5 = new TestData_61()
            {
                Input = new int[] { 1, 2, 3 },
                Val = 2000000000,
                Output = new int[] { 2, 3, 1 }
            };
            if (!CheckResult(test5))
                throw new Exception("Error test 5");
        }

        private static bool CheckResult(TestData_61 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res1 = RotateRight(node, data.Val);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_61
    {
        public int[]? Input { get; set; }
        public int Val { get; set; }
        public int[]? Output { get; set; }
    }
}
