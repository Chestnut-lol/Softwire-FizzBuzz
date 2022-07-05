// See https://aka.ms/new-console-template for more information

namespace FizzBuzz
{
    class Program
    {
        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
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
        static string FizzBuzz(int i)
        {
            string ans;
            if (i % 11 == 0)
            {
                ans = "Bong";
            }
            else if ((i % 3 == 0) | (i % 5 == 0))
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
                ans = Reverse(ans);
            }

            return ans;
        }

        static void Main(string[] args)
        {
            for (int i = 1; i < 200; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }
    }
}