using Leetcode.LinkedList.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    internal class NextGreaterNodeInLinkedList_1019
    {
        public static int[] NextLargerNodes(ListNode? head)
        {
            int length = 0;
            ListNode? temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            int[] res = new int[length];

            temp = head;
            ListNode? temp2 = head;
            int ind = 0;
            while (temp != null)
            {
                int val = temp.val;
                temp2 = temp.next;
                while (temp2 != null)
                {
                    if (val < temp2.val) {
                        res[ind] = temp2.val;
                        break; 
                    }

                    temp2 = temp2.next;
                }

                temp = temp.next;
                ind++;
            }

            return res;
        }

        public static void Check()
        {
            var test1 = new TestData_1019()
            {
                Input = new int[] { 2, 1, 5 },
                Output = new int[] { 5, 5, 0 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_1019()
            {
                Input = new int[] { 2, 7, 4, 3, 5, 1, 1, 1 },
                Output = new int[] { 7, 0, 5, 5, 0, 0, 0, 0 }
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_1019()
            {
                Input = new int[] { 1000, 2, 35, 7, 9, 19, 35, 5 },
                Output = new int[] { 0, 35, 0, 9, 19, 35, 0, 0 }
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_1019 data)
        {
            ListNode? node = ListNode.Factory(data.Input);
            int[] res = NextLargerNodes(node);
            return Compary(res, data.Output);
        }

        private static bool Compary(int[]? arr1, int[]? arr2)
        {
            if (arr1 == null && arr2 == null)
                return true;

            if (arr1?.Length != arr2?.Length)
                return false;

            for (int i = 0; i< arr1?.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;

        }
    }

    internal class TestData_1019
    {
        public int[]? Input { get; set; }
        public int[]? Output { get; set; }
    }
}
