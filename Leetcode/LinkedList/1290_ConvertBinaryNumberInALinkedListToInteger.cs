using Leetcode.LinkedList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    internal class ConvertBinaryNumberInALinkedListToInteger_1290
    {
        public static int GetDecimalValue(ListNode? head)
        {
            int res = 0;
            while (head != null)
            {
                res <<= 1;
                res ^= head.val;
                head = head.next;
            }

            return res;
        }

        public static void Check()
        {
            var test1 = new TestData_1290()
            {
                Input = new int[] { 1, 0, 1 },
                Output = 5
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_1290()
            {
                Input = new int[] { 0 },
                Output = 0
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_1290()
            {
                Input = new int[] { 1 },
                Output = 1
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_1290()
            {
                Input = new int[] { 1, 0, 1, 1, 1, 1 },
                Output = 47
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");
        }

        private static bool CheckResult(TestData_1290 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            int res = GetDecimalValue(node);
            return res == data.Output;
        }
    }

    internal class TestData_1290
    {
        public int[]? Input { get; set; }
        public int Output { get; set; }
    }
}
