using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class ReverseLinkedList_206
    {
        /*public static ListNode? ReverseList(ListNode? head)
        {
            ListNode? temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            int[] list = new int[count];
            count = 0;
            while (head != null)
            {
                list[count] = head.val;
                count++;
                head = head.next;
            }
            return Init(list, list.Count() - 1);
        }*/

        /*public static ListNode? ReverseList(ListNode? head)
        {
            ListNode? after = null;
            ListNode? before = head;
            ListNode? last = head;
            while (last?.next != null)
            {
                while (last?.next?.next != null)
                {
                    last = last.next;
                }

                if (after != null)
                {
                    last.next.next = before;
                    after.next = last.next;
                    after = after.next;
                }
                else
                {
                    last.next.next = before;
                    after = last.next;
                    head = after;
                }
                last.next = null;
                last = before;
            }

            return head;
        }*/

        public static ListNode? ReverseList(ListNode? head)
        {
            ListNode? result = null;
            while (head != null)
            {
                var temp = new ListNode(head.val, result);
                result = temp;
                head = head.next;
            }
            return result;
        }

        private static ListNode? Init(int[] list, int index)
        {
            ListNode? head = null;
            if (index >= 0)
            {
                head = new ListNode(list[index], Init(list, index - 1));
            }
            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_206()
            {
                Input = new int[] { 1, 2, 3, 4, 5 },
                Output = new int[] { 5, 4, 3, 2, 1 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_206()
            {
                Input = new int[] { 1, 2 },
                Output = new int[] { 2, 1 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_206()
            {
                Input = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_206()
            {
                Input = new int[] { 1},
                Output = new int[] { 1 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_206 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            ListNode? res = ReverseList(node);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_206
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
