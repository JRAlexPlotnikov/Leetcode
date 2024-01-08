using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class MergeInBetweenLinkedLists_1669
    {
        public static ListNode? MergeInBetween(ListNode? list1, int a, int b, ListNode? list2)
        {
            ListNode? finish2 = list2;
            while (finish2.next != null)
                finish2 = finish2.next;

            int ind = 0;
            ListNode? temp = list1;
            while (temp != null)
            {
                if (ind == b)
                {
                    finish2.next = temp.next;
                    break;
                }
                ind++;
                temp = temp.next;
            }

            ind = 0;
            temp = list1;
            while (temp != null)
            {
                if (ind == a - 1)
                {
                    temp.next = list2;
                    break;
                }

                ind++;
                temp = temp.next;
            }

            return list1;
        }

        public static void Check()
        {
            var test1 = new TestData_1669()
            {
                Input1 = new int[] { 0, 1, 2, 3, 4, 5 },
                Input2 = new int[] { 1000000, 1000001, 1000002 },
                a = 3,
                b = 4,
                Output = new int[] { 0, 1, 2, 1000000, 1000001, 1000002, 5 },
            };
            if (!CheckResult(test1))
                throw new Exception("Error test");

            var test2 = new TestData_1669()
            {
                Input1 = new int[] { 0, 1, 2, 3, 4, 5, 6 },
                Input2 = new int[] { 1000000, 1000001, 1000002, 1000003, 1000004 },
                a = 2,
                b = 5,
                Output = new int[] { 0, 1, 1000000, 1000001, 1000002, 1000003, 1000004, 6 },
            };
            if (!CheckResult(test2))
                throw new Exception("Error test");
        }

        private static bool CheckResult(TestData_1669 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input1);
            ListNode? test1input2 = ListNode.Factory(data.Input2);
            ListNode? head = MergeInBetween(test1input1, data.a, data.b, test1input2);
            return ListNode.Compary(head, data.Output);
        }
    }

    internal class TestData_1669
    {
        public int[]? Input1 { get; set; }
        public int[]? Input2 { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int[]? Output { get; set; }
    }
}
