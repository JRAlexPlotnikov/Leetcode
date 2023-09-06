using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class IntersectionOfTwoLinkedLists_160
    {
        public static ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB)
        {
            int val;
            bool flag = false;
            while (headA != null)
            {
                val = headA.val;
                headA.val = int.MaxValue;
                ListNode? temp = headB;
                while (temp != null)
                {
                    if (temp.val == int.MaxValue) {
                        flag = true;
                        break;
                    }
                    temp = temp.next;
                }
                headA.val = val;
                if (flag)
                    break;
                headA = headA.next;
            }

            return headA;
        }

        public static void Check()
        {
            var test1 = new TestData_160()
            {
                Input1 = new int[] { 4, 1, 8, 4, 5 },
                Input2 = new int[] { 5, 6, 1 },
                Skip = 2,
                Output = new int[] { 8, 4, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_160()
            {
                Input1 = new int[] { 1, 9, 1, 2, 4 },
                Input2 = new int[] { 3 },
                Skip = 3,
                Output = new int[] { 2, 4 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_160()
            {
                Input1 = new int[] { 2, 6, 4 },
                Input2 = new int[] { 1, 5 },
                Skip = -1,
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_160 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input1);
            ListNode? test1input2 = ListNode.Factory(data.Input2);
            if (data.Skip != -1)
            {
                int i = 0;
                ListNode? node1 = test1input1;
                while (i < data.Skip)
                {
                    i++;
                    node1 = node1.next;
                }

                ListNode? node2 = test1input2;
                while (node2.next != null)
                    node2 = node2.next;

                node2.next = node1;

            }
            ListNode? res1 = GetIntersectionNode(test1input1, test1input2);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_160
    {
        public int[]? Input1 { get; set; }
        public int[]? Input2 { get; set; }
        public int Skip { get; set; }
        public int[]? Output { get; set; }
    }
}
