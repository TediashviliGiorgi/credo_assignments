using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace ExtensionFunctions
{
    public static class MyExtension
    {
        //IsNumber()
        public static bool IsNumber(this string param)
        {
            if (Regex.IsMatch(param, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //IsDate()
        public static bool IsDate(this string param)
        {
            string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                   "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                   "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                   "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};

            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(param, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _) == true)
                {
                    return true;
                }
            }
            return false;
        }

        //ToWords()
        public static string[] ToWords(this string param)
        {
            string[] words = param.Split(' ', ',', '.', '?', ':');
            return words;
        }

        //CalculateHash()
        public static string CalculateHash(this string param)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(param);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        //SaveToFile(string filePath, string txt)
        public static void SaveToFile(string filePath, string fileName, string txt)
        {
            string filePathWithName = $"{filePath}\\{fileName}.txt";
            using (var sw = new StreamWriter(filePathWithName, true))
            {
                sw.WriteLine(txt);
                Console.WriteLine($"Text succesfully saved in {filePath}");
            }
        }
    }
}