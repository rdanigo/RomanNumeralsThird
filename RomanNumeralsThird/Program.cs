using System;

namespace RomanNumeralsThird
{
    class Program
    {
        public class Rule
        {
            public int N { get; set; }
            public string Symbol { get; set; }
            
            public Rule (int n, string symbol)
            {
                N = n;
                Symbol = symbol;
            }
        }

        static Rule[] Rules = new Rule[]
        {
            new Rule(1000, "M"),
            new Rule(900, "CM"),
            new Rule(500, "D"),
            new Rule(400, "CD"),
            new Rule(100, "C"),
            new Rule(90, "XC"),
            new Rule(50, "L"),
            new Rule(40, "XL"),
            new Rule(10, "X"),
            new Rule(9, "IX"),
            new Rule(5, "V"),
            new Rule(4, "IV"),
            new Rule(1, "I"),
        };

        private static string Romanizator(int n)
        {
            if (n == 0)
            {
                return "";
            }
            foreach (var rule in Rules)
            {
                if (rule.N <= n) 
                {
                    return rule.Symbol + Romanizator(n - rule.N);
                }
            }
            throw new ArgumentOutOfRangeException("The number must be bigger than 0");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a number you wish to convert to Roman equal: ");
                int n;
                if (Int32.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    Console.WriteLine("{0} in roman numerals is :\t {1}", n, Romanizator(n));
                } else
                {
                    Console.WriteLine("It seems like something went wrong, please try again");
                }
                Console.ReadKey();
            }
        }
    }
}
