using ExtensionFunctions;
namespace ExtensionFunctionsCaller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IsNumber()
            Console.WriteLine("123".IsNumber());

            //IsDate()
            Console.WriteLine("05/01/2009 6:32:05 PM".IsDate());

            //ToWords()
            string txt = "Is this a word counter? yes it is";
            Console.WriteLine(txt.ToWords().Length);

            //CalculateHash() 
            Console.WriteLine(txt.CalculateHash());

            //SaveToFile(string filePath, string txt)
            string filePath = "D:\\importentFiles\\trainedProjects\\credo-assignments\\ExtensionFunctionsCaller";
            MyExtension.SaveToFile(filePath, "FirstFile", "Test Text");

            //Encrypt
            Console.WriteLine(MyExtension.Encrypt("abc123", "Test Text"));

            //Decrypt ???
            //Console.WriteLine(MyExtension.Decrypt("abc123", "894f666ce383ad5f5316c4861831efbdd63fa9654c947a9b496e269632a4b026"));

            //ToPercent()
            Console.WriteLine(0.5.ToPercent());

            //RoundDown()
            Console.WriteLine(MyExtension.RoundDown(37.7));

            //ToDecimal()
            Console.WriteLine(MyExtension.ToDecimal(5).GetType());

            //IsGreater(double number
            Console.WriteLine(2.2.IsGreater(10.8));

            //IsLess(double number)
            Console.WriteLine(2.2.IsLess(10.8));

            //Min(DateTime date)
            Console.WriteLine(MyExtension.Min(new DateTime(2022, 12, 22), new DateTime(2022, 12, 22)));

            //BeginingOfMonth()
            Console.WriteLine(MyExtension.BeginigOfMonth(new DateTime(2022, 11, 23)));

            //EndOfMonth()
            Console.WriteLine(MyExtension.EndOfMonth(new DateTime(2022, 11, 23)));
        }
    }
}