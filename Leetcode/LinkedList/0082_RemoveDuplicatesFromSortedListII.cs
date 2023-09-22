using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class RemoveDuplicatesFromSortedListII_82
    {
        public static ListNode? DeleteDuplicates(ListNode? head)
        {
            if (head == null)
                return null;

            int countRemove = 0;
            int prevVal = -101;
            bool flag = false;
            ListNode? node = head;
            while (node != null)
            {
                if (prevVal == node.val && !flag)
                {
                    flag = true;
                    countRemove++;
                }
                else if (prevVal != node.val)
                {
                    prevVal = node.val;
                    flag = false;
                }
                node = node.next;
            }

            if (countRemove == 0)
                return head;

            flag = false;
            prevVal = -101;
            node = head;
            int i = 0;
            int[] remove = new int[countRemove];
            while (node != null)
            {
                if (prevVal == node.val && !flag)
                {
                    flag = true;
                    remove[i] = prevVal;
                    i++;
                }
                else if (prevVal != node.val)
                {
                    prevVal = node.val;
                    flag = false;
                }
                node = node.next;
            }

            i = 0;
            node = head;
            ListNode? prev = null;
            while (node != null)
            {
                if (node.val > remove[i])
                    i++;
                if (i == countRemove)
                    break;

                if (node.val == remove[i])
                    if (prev == null)
                        head = node.next;
                    else
                        prev.next = node.next;
                else
                    prev = node;
                node = node.next;

            }


            return head;
        }

        public static void Check()
        {
            var test1 = new TestData_82()
            {
                Input = new int[] { 1, 2, 3, 3, 3, 4, 4, 4, 5 },
                Output = new int[] { 1, 2, 5 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_82()
            {
                Input = new int[] { 1, 2, 3 },
                Output = new int[] { 1, 2, 3 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_82()
            {
                Input = Array.Empty<int>(),
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_82()
            {
                Input = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 123, 123, 124 },
                Output = new int[] { 5, 124 }
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");

            var test5 = new TestData_82()
            {
                Input = new int[] { 1, 1, 2, 2, 3, 3 },
                Output = Array.Empty<int>()
            };
            if (!CheckResult(test5))
                throw new Exception("Error test 5");
        }

        private static bool CheckResult(TestData_82 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input);
            ListNode? res = DeleteDuplicates(test1input1);
            return ListNode.Compary(res, data.Output);
        }
    }

    internal class TestData_82
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
