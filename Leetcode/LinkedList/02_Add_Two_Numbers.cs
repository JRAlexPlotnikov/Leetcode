using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    // https://leetcode.com/problems/add-two-numbers/
    internal class _02_Add_Two_Numbers
    {
        public static ListNode? AddTwoNumbers(ListNode? l1 = null, ListNode? l2 = null, byte overflow = 0)
        {
            ListNode? res = null;
            int sum = overflow;

            if (l1 != null)
            {
                sum += l1.val;
            }

            if (l2 != null)
            {
                sum += l2.val;
            }

            if (l1 != null || l2 != null || overflow > 0)
            {
                res = new ListNode(sum % 10, AddTwoNumbers(l1?.next, l2?.next, (byte)(sum / 10)));
            }
            return res;
        }

        public static void Check()
        {
            var test1 = new _02_TestData()
            {
                Input1 = new int[] { 1, 1, 2, 3, 3 },
                Input2 = new int[] { 1, 1, 2, 3, 3 },
                Output = new int[] { 2, 2, 4, 6, 6 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new _02_TestData()
            {
                Input1 = new int[] { 5, 1, 2, 3, 3 },
                Input2 = Array.Empty<int>(),
                Output = new int[] { 5, 1, 2, 3, 3 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new _02_TestData()
            {
                Input1 = Array.Empty<int>(),
                Input2 = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new _02_TestData()
            {
                Input1 = new int[] { 9, 9, 9, 9, 9, 9, 9 },
                Input2 = new int[] { 9, 9, 9, 9 },
                Output = new int[] { 8, 9, 9, 9, 0, 0, 0, 1 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");

            var test5 = new _02_TestData()
            {
                Input1 = Array.Empty<int>(),
                Input2 = new int[] { 5, 1, 2, 3, 3 },
                Output = new int[] { 5, 1, 2, 3, 3 }
            };
            if (!CheckResult(test5))
                throw new Exception("Error test 5");
        }

        public static bool CheckResult(_02_TestData data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input1);
            ListNode? test1input2 = ListNode.Factory(data.Input2);
            ListNode? res1 = AddTwoNumbers(test1input1, test1input2);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class _02_TestData
    {
        public int[]? Input1 { get; set; }
        public int[]? Input2 { get; set; }
        public int[]? Output { get; set; }
    }
}
