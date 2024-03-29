﻿using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class MergeTwoSortedLists_21
    {
        public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            ListNode? res = null;
            if (list1 != null && (list1.val) < (list2?.val ?? 51))
                res = new ListNode(list1.val, MergeTwoLists(list1.next, list2));
            else if (list2 != null)
                res = new ListNode(list2.val, MergeTwoLists(list1, list2.next));
            return res;
        }

        public static void Check()
        {
            var test1 = new TestData_21()
            {
                Input1 = new int[] { 1, 2, 4 },
                Input2 = new int[] { 1, 3, 4 },
                Output = new int[] { 1, 1, 2, 3, 4, 4 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_21()
            {
                Input1 = Array.Empty<int>(),
                Input2 = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_21()
            {
                Input1 = new int[] { 1, 2, 4 },
                Input2 = Array.Empty<int>(),
                Output = new int[] { 1, 2, 4 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_21()
            {
                Input1 = Array.Empty<int>(),
                Input2 = new int[] { 1, 2, 4 },
                Output = new int[] { 1, 2, 4 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_21 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input1);
            ListNode? test1input2 = ListNode.Factory(data.Input2);
            ListNode? res1 = MergeTwoLists(test1input1, test1input2);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_21
    {
        public int[]? Input1 { get; set; }
        public int[]? Input2 { get; set; }
        public int[]? Output { get; set; }
    }
}
