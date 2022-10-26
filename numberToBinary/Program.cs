namespace numberToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // first way -----------------

            //string ToBinary(long number)
            //{
               
            //    string binary = Convert.ToString(number, 2);
            //    return binary;
            //}

            //----------------------------

            // second way ----------------
            
            string ToBinary(long number)
            {
                long each;
                string result = string.Empty;
                while (number > 0)
                {
                    each = number % 2;
                    number /= 2;
                    result = each.ToString() + result;
                }
                return result;
            }
    
            //----------------------------

            Console.WriteLine(ToBinary(2));
            Console.WriteLine(ToBinary(256));
            Console.WriteLine(ToBinary(33)); 
            Console.WriteLine(ToBinary(999)); 
        }
    }
}