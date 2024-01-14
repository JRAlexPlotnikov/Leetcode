using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class ReorderList_143
    {
        public static ListNode? ReorderList(ListNode? head)
        {
            int length = 0;
            ListNode? temp = head;
            ListNode? revert = null;
            while (temp != null)
            {
                revert = new ListNode(temp.val, revert);
                length++;
                temp = temp.next;
            }

            if (length < 3)
                return head;

            int i = 2;
            temp = head;
            bool f = length % 2 != 0;
            ListNode? next = temp?.next;
            while (temp != null)
            {
                temp.next = f && next == null ? null :
                    new ListNode((revert?.val ?? 0), next);

                if (next == null)
                    break;

                revert = revert?.next;
                temp = temp?.next?.next;

                i++;
                length--;
                next = (i >= length) ? null : temp?.next;

            }

            return head;
        }
        //{
        //    int length = 0;
        //    ListNode? node = head;
        //    while (node != null)
        //    {
        //        length++;
        //        node = node.next;
        //    }

        //    node = head;
        //    int index;
        //    while (node != null && length >= 3)
        //    {
        //        ListNode? first = node;
        //        ListNode? last = node;
        //        while (last.next != null)
        //            last = last.next;

        //        last.next = first.next;
        //        first.next = last;


        //        first = head;
        //        index = 0;
        //        while (index < length - 1)
        //        {
        //            index++;
        //            first = first.next;
        //        }
        //        first.next = null;

        //        node = node?.next?.next;
        //    }

        //    return head;
        //}

        public static void Check()
        {
            var test1 = new TestData_143()
            {
                Input = new int[] { 1, 2, 3, 4 },
                Output = new int[] { 1, 4, 2, 3 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_143()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Output = new int[] { 1, 5, 2, 4, 3 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_143()
            {
                Input = new int[] { 1, 2, 3 },
                Output = new int[] { 1, 3, 2 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_143 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input);
            ListNode? res = ReorderList(test1input1);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_143
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
