using System;

namespace Leetcode.LinkedList.Model
{

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        /*public static ListNode? Factory(int[]? arr, int index = 0)
        {
            ListNode? node = null;
            if (arr != null && arr.Count() > index)
                node = new ListNode(arr[index], Factory(arr, (index + 1)));
            return node;
        }*/

        public static ListNode? Factory(int[]? arr)
        {
            if (arr == null)
                return null;

            ListNode? node = null;
            for (int i = arr.Length - 1; i >= 0; i--)
                node = new ListNode(arr[i], node);
            return node;
        }

        public static bool Compary(ListNode? node, int[]? arr)
        {
            if (node == null && arr == null)
                return true;

            int[] temp = node == null ? Array.Empty<int>() : node.ToArray();
            arr ??= Array.Empty<int>();

            if (arr.Count() != temp.Count())
                return false;

            for (int i = 0; i < arr.Count(); i++)
                if (arr[i] != temp[i])
                    return false;

            return true;
        }

        public int Length()
        {
            int length = 0;
            ListNode? temp = this;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }
            return length;
        }

        public int[] ToArray()
        {
            int length = this.Length();
            int[]? arr = new int[length];
            int i = 0;
            ListNode? temp = this;
            while (temp != null)
            {
                arr[i] = temp.val;
                temp = temp.next;
                i++;
            }

            return arr;
        }
    }
}
