using Leetcode.LinkedList.Model;

namespace Leetcode.LinkedList
{
    internal class SplitLinkedListInParts_725
    {
        public static ListNode?[] SplitListToParts(ListNode? head, int k)
        {
            var result = new ListNode?[k];

            int lengthNode = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                lengthNode++;
                temp = temp.next;
            }

            int count;
            int lamda = lengthNode % k;
            int i = 0;
            int j;
            while (head != null)
            {
                count = lengthNode / k;
                if (lamda > 0)
                {
                    count++;
                    lamda--;
                }

                j = 1;
                temp = head;
                while (j <count)
                {
                    j++;
                    temp = temp.next;
                }

                result[i] = head;
                head = temp?.next;
                temp.next = null;
                i++;
            }

            return result;
        }

        public static void Check()
        {
            var test1 = new TestData_725()
            {
                Input = new int[] { 1, 2, 3 },
                K = 5,
                Output = new List<int[]?>
                {
                    new int[] { 1 },
                    new int[] { 2 },
                    new int[] { 3 },
                    Array.Empty<int>(),
                    Array.Empty<int>(),
                }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_725()
            {
                Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                K = 3,
                Output = new List<int[]?>
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 6, 7 },
                    new int[] { 8, 9, 10 },
                }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            //var test3 = new TestData_725()
            //{
            //    Input = new int[] { 1 },
            //    K = -1,
            //    Output = false
            //};
            //if (!CheckResult(test3))
            //    throw new Exception("Error test 3");

        }

        private static bool CheckResult(TestData_725 data)
        {
            ListNode? test1input1 = ListNode.Factory(data.Input);
            ListNode?[] resultNode = SplitListToParts(test1input1, data.K);
            bool result = false;
            if (resultNode.Length == data.K && data.K == data.Output.Count)
            {
                result = true;
                for (int i = 0; i < resultNode.Length; i++)
                    result &= ListNode.Compary(resultNode[i], data.Output[i]);
            }
            return result;
        }
    }

    internal class TestData_725
    {
        public int[]? Input { get; set; }
        public int K { get; set; }
        public List<int[]?> Output { get; set; }
    }
}
