using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    //  https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    internal class _83_Remove_Duplicates_from_Sorted_List
    {
        public static ListNode? DeleteDuplicates(ListNode? head, int last = -101)
        {
            ListNode? result = null;
            while (head != null && head.val == last)
            {
                head = head.next;
            }
            if (head != null)
            {
                result = new ListNode(head.val, DeleteDuplicates(head.next, head.val));
            }
            return result;
        }

        public static void Check()
        {
            var test1 = new _83_TestData()
            {
                Input = new int[] { 1, 1, 2, 3, 3 },
                Output = new int[] { 1, 2, 3 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new _83_TestData()
            {
                Input = new int[] { 1, 2, 3 },
                Output = new int[] { 1, 2, 3 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new _83_TestData()
            {
                Input = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new _83_TestData()
            {
                Input = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 123, 123, 124 },
                Output = new int[] { 1, 2, 3, 4, 5, 6, 7, 123, 124 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(_83_TestData data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input, 0);
            ListNode? res = DeleteDuplicates(test1input1);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class _83_TestData
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
