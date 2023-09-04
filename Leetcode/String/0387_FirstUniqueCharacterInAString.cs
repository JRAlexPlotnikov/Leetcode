using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.String
{
    internal class FirstUniqueCharacterInAString_0387
    {
        public static int FirstUniqChar(string s)
        {
            int result = -1;
            List<char> list = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (list.Contains(s[i]))
                    continue;

                bool duplicate = false;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                {
                    result = i;
                    break;
                }
                list.Add(s[i]);
            }
            return result;
        }

        public static void Check()
        {
            var test1 = new TestData_387()
            {
                Input = "leetcode",
                Output = 0
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_387()
            {
                Input = "loveleetcode",
                Output = 2
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_387()
            {
                Input = "aabb",
                Output = -1
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");
        }

        private static bool CheckResult(TestData_387 data)
        {
            int res = FirstUniqChar(data.Input);
            return res == data.Output;
        }
    }

    internal class TestData_387
    {
        public string Input { get; set; }
        public int Output { get; set; }
    }
}
