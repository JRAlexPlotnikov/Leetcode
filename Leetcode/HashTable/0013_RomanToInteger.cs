namespace Leetcode.HashTable
{
    internal class RomanToInteger_13
    {
        public static int RomanToInt(string s)
        {
            char next;
            int res = 0;
            int i = 0;
            do
            {
                char c = s[i];
                switch (c)
                {
                    case 'I':
                        next = (i + 1 < s.Length) ? s[i + 1] : 'N';
                        switch (next)
                        {
                            case 'V':
                                res += 4;
                                i++;
                                break;
                            case 'X':
                                res += 9;
                                i++;
                                break;
                            default:
                                res += 1;
                                break;
                        }
                        break;
                    case 'V':
                        res += 5;
                        break;
                    case 'X':
                        next = (i + 1 < s.Length) ? s[i + 1] : 'N';
                        switch (next)
                        {
                            case 'L':
                                res += 40;
                                i++;
                                break;
                            case 'C':
                                res += 90;
                                i++;
                                break;
                            default:
                                res += 10;
                                break;
                        }
                        break;
                    case 'L':
                        res += 50;
                        break;
                    case 'C':
                        next = (i + 1 < s.Length) ? s[i + 1] : 'N';
                        switch (next)
                        {
                            case 'D':
                                res += 400;
                                i++;
                                break;
                            case 'M':
                                res += 900;
                                i++;
                                break;
                            default:
                                res += 100;
                                break;
                        }
                        break;
                    case 'D':
                        res += 500;
                        break;
                    case 'M':
                        res += 1000;
                        break;
                    default:
                        break;
                }
                i++;
            }
            while (i < s.Length);
            return res;
        }

        public static void Check()
        {
            var test = new TestData_13()
            {
                Input = "III",
                Output = 3
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 1");

            test = new TestData_13()
            {
                Input = "LVIII",
                Output = 58
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 2");

            test = new TestData_13()
            {
                Input = "MCMXCIV",
                Output = 1994
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 3");
        }

        private static bool CheckResult(TestData_13 data)
        {
            int res = RomanToInt(data.Input);
            return res == data.Output;
        }
    }

    internal class TestData_13
    {
        public string Input { get; set; } = "";
        public int Output { get; set; }
    }
}
