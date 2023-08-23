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

        public static ListNode? Factory(int[] arr, int index)
        {
            ListNode? node = null;
            if (arr.Count() > index)
                node = new ListNode(arr[index], Factory(arr, (index + 1)));
            return node;
        }

        public bool Compary(int[] arr)
        {
            int[] temp = ToArray();

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
            int[] arr = new int[Length()];
            int i = 0;
            ListNode? temp = this;
            while (temp != null)
            {
                arr[i] = temp.val;
                i++;
                temp = temp.next;
            }

            return arr;
        }
    }
}
