using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace WordAnalizer
{
    public class Program
    {
        public static string[] ReadFile()
        {
            string txt = System.IO.File.ReadAllText("D:\\importentFiles\\trainedProjects\\credo-assignments\\WordAnalizer\\words_alpha.txt");
            string[] words = txt.Split(' ', '.', ',', '?', '\n');
            return words;

        }
        //get shortest word ----------------------------------
        public static void GetShortestWord()
        {
            string[] words = ReadFile();
            string shortestWord = words[0];
            foreach (string i in words)
            {
                if (i.Length < words[0].Length)
                {
                    shortestWord = i;
                }
            }
            Console.WriteLine(shortestWord);
        }
        //---------------------------------------------------
        //get shortest word ----------------------------------
        public static void GetLargestWord()
        {
            string[] words = ReadFile();
            string largestWord = words[0];
            foreach (string i in words)
            {
                if (i.Length > words[0].Length)
                {
                    largestWord = i;
                }
            }
            Console.WriteLine(largestWord);
        }

        //---------------------------------------------------

        //get 100 word with most frecuent vowel----------------------------------
        public static void getTop100ByVoWelQuantity()
        {
            string[] words = ReadFile();
            List<WordsWithVowelQuantity> wordsWithVowelQuantities = new List<WordsWithVowelQuantity>();
           
            foreach (string i in words)
            {
                WordsWithVowelQuantity wordObj = new WordsWithVowelQuantity();
                wordObj.Word = i;
                int count = 0;
                foreach (char j in i)
                {
                    if (j == 'a' || j == 'e' || j == 'i' || j == 'o' || j == 'u')
                    {
                        count++;
                    }
                    wordObj.VowelQuantity = count;
                    
                }
                wordsWithVowelQuantities.Add(wordObj);
            }

            var sorted = wordsWithVowelQuantities.OrderByDescending(ob => ob.VowelQuantity).Take(100).ToList();  
            foreach(var obj in sorted)
            {
                Console.WriteLine(obj.Word);
            }
        }
        //---------------------------------------------------
        static void Main(string[] args)
        {
            
            var watch = new Stopwatch();
            watch.Start();
            Parallel.Invoke(() => GetShortestWord(), () => GetLargestWord(), () => getTop100ByVoWelQuantity());
            //GetShortestWord();
            //GetLargestWord();
            //getTop100ByVoWelQuantity();
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);

        }
    }
}