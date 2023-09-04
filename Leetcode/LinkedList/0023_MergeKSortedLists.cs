using Leetcode.LinkedList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    internal class MergeKSortedLists_23
    {
        public static ListNode? MergeKLists(ListNode?[] lists)
        {
            ListNode? result = null;

            if (lists != null)
            {
                int min = Int32.MaxValue;
                int index = -1;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null && min > lists[i].val)
                    {
                        min = lists[i].val;
                        index = i;
                    }
                }

                if (index == -1)
                    return result;
                else
                {                 
                    lists[index] = lists[index].next;
                    result = new ListNode(min, MergeKLists(lists));
                }
            }
            return result;
        }

        public static void Check()
        {
            var test1 = new TestData_23()
            {
                Input = new List<int[]>()
                {
                    new int[] { 1,4,5 },
                    new int[] { 1,3,4 },
                    new int[] { 2,6 },

                },
                Output = new int[] { 1, 1, 2, 3, 4, 4, 5, 6 }
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");


        }

        private static bool CheckResult(TestData_23 data)
        {
            var input = new ListNode?[data.Input.Count];
            for (int i = 0; i < input.Length; i++)
            {
                ListNode? node = ListNode.Factory(data.Input[i]);
                input[i] = node;
            }
            ListNode? res1 = MergeKLists(input);
            return ListNode.Compary(res1, data.Output);
        }
    }

    internal class TestData_23
    {
        public List<int[]> Input { get; set; }
        public int[]? Output { get; set; }
    }
}
