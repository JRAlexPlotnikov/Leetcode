using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class RemoveNthNodeFromEndOfList_19
    {
        public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
        {
            int count = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            if (n == 1 && count == 1)
            {
                head = null;
            }
            else if (n == count)
            {
                head = head?.next;
            }
            else
            {
                temp = head;
                while (temp != null)
                {
                    count--;
                    if (count == n)
                    {
                        temp.next = temp?.next?.next;
                        break;
                    }
                    temp = temp.next;
                }
            }

            return head;
        }

        //public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
        //{
        //    ListNode? revert = null;
        //    while (head != null)
        //    {
        //        revert = new ListNode(head.val, revert);
        //        head = head.next;
        //    }

        //    if (n == 1)
        //    {
        //        revert = revert?.next;
        //    }
        //    else
        //    {
        //        int i = 1;
        //        head = revert;
        //        while (head != null)
        //        {
        //            if (i == n - 1)
        //            {
        //                head.next = head?.next?.next;
        //                break;
        //            }
        //            i++;
        //            head = head.next;
        //        }
        //    }

        //    head = null;
        //    while (revert != null)
        //    {
        //        head = new ListNode(revert.val, head);
        //        revert = revert.next;
        //    }

        //    return head;
        //}


        //public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
        //{
        //    int length = 0;
        //    ListNode? temp = head;
        //    while (temp != null)
        //    {
        //        length++;
        //        temp = temp.next;
        //    }

        //    n = length - n;

        //    return RemoveNthFromStart(head, n, 0);
        //}

        //private static ListNode? RemoveNthFromStart(ListNode? head, int n, int index)
        //{
        //    ListNode? temp = null;
        //    if (head != null && n == index)
        //        head = head.next;

        //    if (head != null)
        //    {
        //        temp = new ListNode(head.val, RemoveNthFromStart(head.next, n, (index + 1)));
        //    }
        //    return temp;
        //}

        public static void Check()
        {
            var test1 = new TestData_19()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                N = 2,
                Output = new int[] { 1, 2, 3, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test");

            var test2 = new TestData_19()
            {
                Input = new int[] { 1 },
                N = 1,
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test2))
                throw new Exception("Error test");

            var test3 = new TestData_19()
            {
                Input = new int[] { 1, 2 },
                N = 1,
                Output = new int[] { 1 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test");

            var test4 = new TestData_19()
            {
                Input = new int[] { 1, 2, 3 },
                N = 3,
                Output = new int[] { 2, 3 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test");
        }

        private static bool CheckResult(TestData_19 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res1 = RemoveNthFromEnd(node, data.N);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_19
    {
        public int[]? Input { get; set; }
        public int N { get; set; }
        public int[]? Output { get; set; }
    }
}
