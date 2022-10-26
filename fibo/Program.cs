namespace fibo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static long  Fib (int n)
               
            {
                
                if (n == 0)
                {
                    return 0;
                }
                else if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return Fib(n - 1) + Fib(n - 2);
                }
            }
            Console.WriteLine("Please enter position");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }
    }
}