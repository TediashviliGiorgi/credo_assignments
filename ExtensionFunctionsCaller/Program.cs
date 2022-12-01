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
        }
    }
}