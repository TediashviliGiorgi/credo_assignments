namespace vowelOrNot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsVowel(char x)
            {
                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'ა', 'ე', 'ი', 'ო', 'უ' };
                x = Char.ToLower(x);
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (vowels[i] == x)
                    {
                        return true;
                    }
                }
                return false;
            }

            //using case
            var isVowel = IsVowel('a');
            Console.WriteLine(isVowel);
            isVowel = IsVowel('b');
            Console.WriteLine(isVowel);
            isVowel = IsVowel('ე');
            Console.WriteLine(isVowel);
            isVowel = IsVowel('კ');
            Console.WriteLine(isVowel);
        }
    }
}