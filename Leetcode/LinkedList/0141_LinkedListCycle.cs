using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class LinkedListCycle_141
    {
        public static bool HasCycle(ListNode? head)
        {
            while (head != null)
            {
                if (head.val == int.MinValue)
                    return true;

                head.val = int.MinValue;
                head = head.next;
            }
            return false;
        }

        public static void Check()
        {
            var test1 = new TestData_141()
            {
                Input = new int[] { 3, 2, 0, -4 },
                Pos = 1,
                Output = true
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_141()
            {
                Input = new int[] { 1, 2 },
                Pos = 0,
                Output = true
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_141()
            {
                Input = new int[] { 1 },
                Pos = -1,
                Output = false
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_141()
            {
                Input = new int[] { 1, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4, 2, 0, -4 },
                Pos = -1,
                Output = false
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_141 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input, 0);
            if (data.Pos >= 0)
            {
                ListNode? head = test1input1;
                ListNode? node = null;
                int i = 0;
                while (head != null)
                {
                    if (i == data.Pos)
                        node = head;

                    if (head.next == null)
                    {
                        head.next = node;
                        break;
                    }

                    head = head.next;
                    i++;
                }
            }
            bool res = HasCycle(test1input1);
            return res == data.Output;
        }
    }

    internal class TestData_141
    {
        public int[]? Input { get; set; }
        public int Pos { get; set; }
        public bool Output { get; set; }
    }
}
