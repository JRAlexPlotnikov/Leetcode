namespace Leetcode.String
{
    internal class LongestSubstringWithoutRepeatingCharacters_0003
    {
        public static int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            int i = 0;
            int j;
            string str;
            while (i != s.Length && max < s.Length - i)
            {
                str = s[i].ToString();
                j = i + 1;

                while (j < s.Length  && !str.Contains(s[j]))
                {
                    str += s[j];
                    j++;
                }

                if (j - i > max)
                    max = j - i;

                if (j >= s.Length)
                    break;

                i += str.IndexOf(s[j]) + 1;
            }

            return max;
        }

        public static void Check()
        {
            var test1 = new TestData_3()
            {
                Input = "pwwkxczswedascxcasdascaxcasdaew",
                Output = 9
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_3()
            {
                Input = "bbbbb",
                Output = 1
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_3()
            {
                Input = "pwwkew",
                Output = 3
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

            var test4 = new TestData_3()
            {
                Input = "abcabcbb",
                Output = 3
            };
            if (!CheckResult(test4))
                throw new Exception("Error test 4");

            var test5 = new TestData_3()
            {
                Input = "abcaabcbcbscavbabc",
                Output = 5
            };
            if (!CheckResult(test5))
                throw new Exception("Error test 5");
        }

        private static bool CheckResult(TestData_3 data)
        {
            int res = LengthOfLongestSubstring(data.Input);
            return res == data.Output;
        }
    }

    internal class TestData_3
    {
        public string Input { get; set; }
        public int Output { get; set; }
    }
}
