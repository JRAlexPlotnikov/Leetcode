namespace Leetcode.String
{
    internal class LengthOfLastWord_0058
    {
        public static int LengthOfLastWord(string s)
        {
            return s.Trim().Reverse().TakeWhile(c => c != ' ').Count();
        }

        public static void Check()
        {
            var test1 = new TestData_58()
            {
                Input = "Hello World",
                Output = 5
            };
            if (!CheckResult(test1))
                throw new Exception("Error test 1");

            var test2 = new TestData_58()
            {
                Input = "   fly me   to   the moon  ",
                Output = 4
            };
            if (!CheckResult(test2))
                throw new Exception("Error test 2");

            var test3 = new TestData_58()
            {
                Input = "luffy is still joyboy",
                Output = 6
            };
            if (!CheckResult(test3))
                throw new Exception("Error test 3");

        }

        private static bool CheckResult(TestData_58 data)
        {
            int res = LengthOfLastWord(data.Input);
            return res == data.Output;
        }
    }

    internal class TestData_58
    {
        public string Input { get; set; }
        public int Output { get; set; }
    }
}
