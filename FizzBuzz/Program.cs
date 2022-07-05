// See https://aka.ms/new-console-template for more information


namespace FizzBuzz
{
    class Utilities
    {
        public const string BREAKLINE = "=================";
        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
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
    }
    class Program
    {
        static string Is3or5(int i)
        {
            string res;
            if ((i % 3 == 0) & (i % 5 == 0))
            {
                res = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                res = "Fizz";
            }
            else //(i % 5 == 0)
            {
                res = "Buzz";
            }
            return res;
        }

        static string Is13(string ans)
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
        static string FizzBuzzFullVersion(int i)
        {
            string ans;
            if (i % 11 == 0)
            {
                ans = "Bong";
            }
            else if ((i % 3 == 0) || (i % 5 == 0))
            {
                ans = Is3or5(i);
                if (i % 7 == 0)
                {
                    ans += "Bang";
                }
            }
            else if (i % 7 == 0)
            {
                ans = "Bang";
            }
            else
            {
                ans = i.ToString();
            }

            if (i % 13 == 0)
            {
                ans = Is13(ans);
            }

            if (i % 17 == 0)
            {
                ans = Utilities.Reverse(ans);
            }

            return ans;
        }


        static void Main(string[] args)
        {
            int MaxNum = Utilities.GetIntInput("Welcome! Please specify maximum number: ");
            Console.WriteLine(Utilities.BREAKLINE);
            for (int i = 1; i < MaxNum+1; i++)
            {
                Console.WriteLine(FizzBuzzFullVersion(i));
            }
        }
    }
}