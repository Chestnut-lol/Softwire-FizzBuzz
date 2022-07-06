// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Globalization;
using FizzBuzz;

namespace FizzBuzz
{
    class Utilities
    {
        public const string BREAKLINE = "=================";

        public static string Reverse(string s)
        {
            var words = string.Concat(s.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                .TrimStart().Split(' ');
            string res = "";
            foreach (string word in words)
            {
                res = word + res;
            }

            return res;
        }

        public static int GetIntInput(string msg)
        {
            Console.WriteLine(msg);
            int num;
            if (int.TryParse(Console.ReadLine(), out int ans))
            {
                num = ans;
            }
            else
            {
                Console.WriteLine("Invalid input! Try again.");
                Console.WriteLine(BREAKLINE);
                num = GetIntInput(msg);
            }

            return num;
        }

        public static int[] PrimeArr =
            { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public static bool CheckPrime(int num)
        {
            return Array.Exists(PrimeArr, elt => elt == num);
        }
    }

    public class Program
    {
        static int GetMaxNum()
        {
            int MaxNum = Utilities.GetIntInput("Welcome! Please specify maximum number: ");
            Console.WriteLine(Utilities.BREAKLINE);
            return MaxNum;
        }
        static void Main(string[] args)
        {
            int MaxNum = GetMaxNum();
            
            // ======================================================
            // Comment out to run FizzBuzzFullVersion
            // ======================================================
            int divisor_fizz = FizzBuzzFullVersion.Get_number("fizz");
            int divisor_buzz = FizzBuzzFullVersion.Get_number("buzz");
            int divisor_bang = FizzBuzzFullVersion.Get_number("bang");
            int divisor_bong = FizzBuzzFullVersion.Get_number("bong");
            int divisor_fezz = FizzBuzzFullVersion.Get_number("fezz");
            int divisor_reverse = FizzBuzzFullVersion.Get_number("reverse");
            for (int i = 1; i < MaxNum + 1; i++)
            {
                Console.WriteLine(FizzBuzzFullVersion.run(i, divisor_fizz, divisor_buzz, divisor_bang, divisor_bong,
                    divisor_fezz, divisor_reverse));
            }
            
            // =======================================================
            // Comment out to run IEnumerator
            // =======================================================
            /*
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var fizzBuzzer = new FizzBuzzer(nums);
            foreach (var val in fizzBuzzer)
            {
                Console.WriteLine(val);
            }*/
            
            // =======================================================
            // Comment out to run FizzBuzzSimpleVersion
            // ========================================================
            /*for (int i = 1; i < MaxNum + 1; i++)
            {
                Console.WriteLine(FizzBuzzSimpleVersion.run(i));
            }*/
        }
    }

    class FizzBuzzSimpleVersion
    {
        private const int divisor_fizz = 3;
        private const int divisor_buzz = 5;
        static string FizzBuzzRule(int i)
        {
            string res;
            if ((i % divisor_fizz == 0) & (i % divisor_buzz == 0))
            {
                res = "FizzBuzz";
            }
            else if (i % divisor_fizz == 0)
            {
                res = "Fizz";
            }
            else //(i % divisor_buzz == 0)
            {
                res = "Buzz";
            }

            return res;
        }

        public static string run(int i)
        {
            string ans;
            if ((i % 3 == 0) || (i % 5 == 0))
            {
                ans = FizzBuzzRule(i);
            }
            else
            {
                ans = i.ToString();
            }

            return ans;
        }
    }

    
    class FizzBuzzFullVersion
    {
        static string FizzBuzzRule(int i, int divisor_fizz, int divisor_buzz)
        {
            string res;
            if ((i % divisor_fizz == 0) & (i % divisor_buzz == 0))
            {
                res = "FizzBuzz";
            }
            else if (i % divisor_fizz == 0)
            {
                res = "Fizz";
            }
            else //(i % divisor_buzz == 0)
            {
                res = "Buzz";
            }

            return res;
        }

        static string FezzRule(string ans)
        {
            // Check if ans is numeric
            if (int.TryParse(ans, out int _))
            {
                return "Fezz";
            }

            int idx = ans.IndexOf('B');
            if (idx == -1)
            {
                ans += "Fezz";
            }
            else
            {
                ans = ans.Insert(idx, "Fezz");
            }

            return ans;
        }

        public static string run(int i,
            int divisor_fizz,
            int divisor_buzz,
            int divisor_bang,
            int divisor_bong,
            int divisor_fezz,
            int divisor_reverse)
        {
            string ans;


            if (i % divisor_bong == 0)
            {
                ans = "Bong";
            }
            else if ((i % divisor_fizz == 0) || (i % divisor_buzz == 0))
            {
                ans = FizzBuzzRule(i, divisor_fizz, divisor_buzz);
                if (i % divisor_bang == 0)
                {
                    ans += "Bang";
                }
            }
            else if (i % divisor_bang == 0)
            {
                ans = "Bang";
            }
            else
            {
                ans = i.ToString();
            }

            if (i % divisor_fezz == 0)
            {
                ans = FezzRule(ans);
            }

            if (i % divisor_reverse == 0)
            {
                if (int.TryParse(ans, out int _))
                {
                    ;
                }
                else
                {
                    ans = Utilities.Reverse(ans);
                }
            }

            return ans;
        }

        public static int Get_number(string word)
        {

            int divisor;
            int ans = Utilities.GetIntInput($"Please specify {word} number (prime number smaller than 100): ");
            if (ans >= 100)
            {
                ans = Utilities.GetIntInput($"The input number is >= 100, try again: ");
            }

            if (!Utilities.CheckPrime(ans))
            {
                Console.WriteLine("Not a prime! Try again.");
                ans = Get_number(word);
            }

            return ans;
        }
    }
    }

    
    // IEnumration

    public class FizzBuzzer : IEnumerable
    {
        private string[] _answers;

        public FizzBuzzer(int[] nums)
        {
            _answers = new string[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int divisor_fizz = 3;//Get_number("fizz");
                int divisor_buzz = 5;//Get_number("buzz");
                int divisor_bang = 7;//Get_number("bang");
                int divisor_bong = 11;//Get_number("bong");
                int divisor_fezz = 13;//Get_number("fezz");
                int divisor_reverse = 17;//Get_number("reverse");
                _answers[i] = FizzBuzzFullVersion.run(i,
                    divisor_fizz,
                    divisor_buzz,
                    divisor_bang,
                    divisor_bong,
                    divisor_fezz,
                    divisor_reverse);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new FizzBuzzEnumerator(_answers);
        }



        public class FizzBuzzEnumerator : IEnumerator
        {

            public string[] _answers;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public FizzBuzzEnumerator(string[] list)
            {
                _answers = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _answers.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get { return _answers[position]; }
            }

        }

    }




