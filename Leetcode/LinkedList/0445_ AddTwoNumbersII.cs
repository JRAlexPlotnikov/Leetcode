using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class AddTwoNumbersII_0445
    {
        public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            ListNode? temp = l1;
            ListNode? r1 = null;
            while(temp!=null)
            {
                r1 = new ListNode(temp.val, r1);
                temp = temp.next;
            }

            temp = l2;
            ListNode? r2 = null;
            while (temp != null)
            {
                r2 = new ListNode(temp.val, r2);
                temp = temp.next;
            }

            temp = null;
            bool next = false;
            int val = 0; 
            while (r1 != null || r2 != null || next)
            {
                val = (r1?.val ?? 0) + (r2?.val ?? 0) + Convert.ToInt32(next);
                next = val / 10 == 1;
                temp = new ListNode(val % 10, temp);

                r1 = r1?.next;
                r2 = r2?.next;
            }

            return temp;
        }

        public static void Check()
        {
            var test4 = new TestData_0445()
            {
                Input1 = new int[] { 9 },
                Input2 = new int[] { 9 },
                Output = new int[] { 1, 8 },
            };
            if (!CheckResult(test4))
                throw new Exception("Error test");

            var test1 = new TestData_0445()
            {
                Input1 = new int[] { 7, 2, 4, 3 },
                Input2 = new int[] { 5, 6, 4 },
                Output = new int[] { 7, 8, 0, 7 },
            };
            if (!CheckResult(test1))
                throw new Exception("Error test");

            var test2 = new TestData_0445()
            {
                Input1 = new int[] { 2, 4, 3 },
                Input2 = new int[] { 5, 6, 4 },
                Output = new int[] { 8, 0, 7 },
            };
            if (!CheckResult(test2))
                throw new Exception("Error test");

            var test3 = new TestData_0445()
            {
                Input1 = new int[] { 9 },
                Input2 = new int[] { 9 },
                Output = new int[] { 1, 8 },
            };
            if (!CheckResult(test3))
                throw new Exception("Error test");
        }

        private static bool CheckResult(TestData_0445 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input1);
            ListNode? test1input2 = ListNode.Factory(data.Input2);
            ListNode? head = AddTwoNumbers(test1input1, test1input2);
            return ListNode.Compary(head, data.Output);
        }
    }

    internal class TestData_0445
    {
        public int[]? Input1 { get; set; }
        public int[]? Input2 { get; set; }
        public int[]? Output { get; set; }
    }
}
