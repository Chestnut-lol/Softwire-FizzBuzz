// See https://aka.ms/new-console-template for more information

namespace FizzBuzz
{
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
        static string FizzBuzz(int i)
        {
            if ((i % 3 == 0) | (i % 5 == 0))
            {
                string ans = Is3or5(i);
                if (i % 7 == 0)
                {
                    ans += "Bang";
                    
                }
                return ans;
            }
            else
            {
                return i.ToString();
                
            }
        }

        static void Main(string[] args)
        {
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }
    }
}