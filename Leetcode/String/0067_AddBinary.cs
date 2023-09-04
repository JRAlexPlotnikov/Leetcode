using Leetcode.LinkedList.Model;
using Leetcode.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.String
{
    internal class AddBinary_67
    {
        public static string AddBinary(string a, string b)
        {
            char[] aa, bb;
            if (a.Length >= b.Length)
            {
                aa = a.ToCharArray();
                bb = b.ToCharArray();
            }
            else
            {
                aa = b.ToCharArray();
                bb = a.ToCharArray();
            }

            Array.Reverse(aa);
            Array.Reverse(bb);

            a = "";
            bool overflow = false;
            for (int i = 0; i < aa.Count(); i++)
            {
                char temp = (i < bb.Count()) ? bb[i] : '0';

                if ((aa[i] == '1' && temp == '1') && !overflow)
                {
                    a += '0';
                    overflow = true;
                }
                else if ((aa[i] == '1' && temp == '1') && overflow
                    || (aa[i] == '1' && temp == '0' || aa[i] == '0' && temp == '1') && !overflow)
                {
                    a += '1';
                }
                else if ((aa[i] == '1' && temp == '0' || aa[i] == '0' && temp == '1') && overflow
                        || aa[i] == '0' && temp == '0' && !overflow)
                {
                    a += '0';
                }
                else if (aa[i] == '0' && temp == '0' && overflow)
                {
                    a += '1';
                    overflow = false;
                }
            }

            if (overflow)
                a += '1';

            aa = a.ToCharArray();
            Array.Reverse(aa);

            return new string(aa);
        }

        public static void Check()
        {
            var test1 = new TestData_67()
            {
                Input1 = "11",
                Input2 = "1",
                Output = "100"
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_67()
            {
                Input1 = "1010",
                Input2 = "1011",
                Output = "10101"
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");
        }

        private static bool CheckResult(TestData_67 data)
        {
            string res = AddBinary(data.Input1, data.Input2);
            return res == data.Output;
        }
    }

    internal class TestData_67
    {
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Output { get; set; }
    }
}
