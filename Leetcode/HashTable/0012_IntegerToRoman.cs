namespace Leetcode.HashTable
{
    internal class IntegerToRoman_0012
    {
        public static string IntToRoman(int num)
        {
            string res = "";

            do
            {
                if (num - 1000 >= 0)
                {
                    res += 'M';
                        num -= 1000;
                }
                else if (num - 900 >= 0)
                {
                    res += "CM";
                    num -= 900;
                }
                else if (num - 500 >= 0)
                {
                    res += 'D';
                    num -= 500;
                }
                else if (num - 400 >= 0)
                {
                    res += "CD";
                    num -= 400;
                }
                else if (num - 100 >= 0)
                {
                    res += 'C';
                    num -= 100;
                }
                else if (num - 90 >= 0)
                {
                    res += "XC";
                    num -= 90;
                }
                else if (num - 50 >= 0)
                {
                    res += 'L';
                    num -= 50;
                }
                else if (num - 40 >= 0)
                {
                    res += "XL";
                    num -= 40;
                }
                else if (num - 10 >= 0)
                {
                    res += 'X';
                    num -= 10;
                }
                else if (num - 9 >= 0)
                {
                    res += "IX";
                    num -= 9;
                }
                else if (num - 5 >= 0)
                {
                    res += 'V';
                    num -= 5;
                }
                else if (num - 4 >= 0)
                {
                    res += "IV";
                    num -= 4;
                }
                else if (num - 1 >= 0)
                {
                    res += 'I';
                    num -= 1;
                }
            }
            while (num > 0);

            return res;
        }

        public static void Check()
        {
            var test = new TestData_12()
            {
                Input = 3749,
                Output = "MMMDCCXLIX"
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 1");

            test = new TestData_12()
            {
                Input = 58,
                Output = "LVIII"
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 2");

            test = new TestData_12()
            {
                Input = 1994,
                Output = "MCMXCIV"
            };
            if (!CheckResult(test))
                Console.WriteLine("Error test 3");
        }

        private static bool CheckResult(TestData_12 data)
        {
            string res = IntToRoman(data.Input);
            return res == data.Output;
        }
    }

    internal class TestData_12
    {
        public int Input { get; set; }
        public string Output { get; set; } = "";
    }
}
