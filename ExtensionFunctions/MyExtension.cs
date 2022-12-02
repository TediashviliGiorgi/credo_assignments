using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Runtime.CompilerServices;

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

        //Encrypt
        public static string Encrypt(string key, string txt)
        {
            string EncryptionKey = key;
            byte[] clearBytes = Encoding.Unicode.GetBytes(txt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    txt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return txt;
        }

        //Decrypt
        public static string Decrypt(string key, string txt)
        {
            string EncryptionKey = key;
            txt = txt.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(txt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    txt = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return txt;
        }

        //ToPercent()
        public static double ToPercent(this double param)
        {
            return param * 100;
        }

        //RoundDown()
        public static int RoundDown(double param)
        {
            int number = (int)Math.Floor(param);
            return number;
        }

        //ToDecimal()
        public static decimal ToDecimal(int param)
        {
            decimal number = (decimal)param;
            return number;
        }

        //IsGreater(double number
        public static bool IsGreater(this double param, double number)
        {
           if(param > number)
            {
                return true;
            }
            return false;
        }

        //IsLess(double number)
        public static bool IsLess(this double param, double number)
        {
            if (param < number)
            {
                return true;
            }
            return false;
        }

        //Min(DateTime date)
        public static DateTime Min(DateTime d1, DateTime d2)
        {
            int minDate = DateTime.Compare(d1, d2);
            
            if (minDate < 0 )
            {
                return d2;
            }
            else
            {
                return d1;  
            }
        }

        //BeginingOfMonth()
        public static DateTime BeginigOfMonth(this DateTime param)
        {
            return new DateTime(param.Year, param.Month, 1);
        }

        //EndOfMonth()
        public static DateTime EndOfMonth(this DateTime param)
        {
            var firstDayOfMonth = new DateTime(param.Year, param.Month, 1);
            return firstDayOfMonth.AddMonths(1).AddDays(-1);
        }
    }
}
