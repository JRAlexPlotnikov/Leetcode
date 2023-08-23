using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    //  https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    internal class _83_Remove_Duplicates_from_Sorted_List : ITask
    {
        public ListNode? DeleteDuplicates(ListNode? head, int last = -101)
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

        public static void Ckeck()
        {
            var obj = new _83_Remove_Duplicates_from_Sorted_List();

            ListNode? test1input1 = ListNode.Factory(new int[] { 1, 1, 2, 3, 3 }, 0);
            int[] test1output1 = new int[] { 1, 2, 3 };
            ListNode? res1 = obj.DeleteDuplicates(test1input1);
            if (res1 == null && !res1.Compary(test1output1))
                throw new Exception("Error test 1");

            ListNode? test2input1 = ListNode.Factory(new int[] { 1, 2, 3 }, 0);
            int[] test2output1 = new int[] { 1, 2, 3 };
            ListNode? res2 = obj.DeleteDuplicates(test2input1);
            if (res2 == null && !res2.Compary(test2output1))
                throw new Exception("Error test 2");

            ListNode? test3input1 = ListNode.Factory(new int[] { }, 0);
            //int[] test3output1 = new int[] { };
            ListNode? res3 = obj.DeleteDuplicates(test3input1);
            if (res3 != null)
                throw new Exception("Error test 3");

            ListNode? test4input1 = ListNode.Factory(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 123, 123, 124 }, 0);
            int[] test4output1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 123, 124 };
            ListNode? res4 = obj.DeleteDuplicates(test4input1);
            if (res4 != null && !res4.Compary(test4output1))
                throw new Exception("Error test 4");
        }
    }
}
