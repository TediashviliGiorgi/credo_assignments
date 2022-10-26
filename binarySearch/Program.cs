using System.Security.Cryptography.X509Certificates;

namespace binarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-----------Linear Search -----------------
           int LinearSearch(int[] array, int target)
            {
                for(int i = array.Length - 1; i >= 0; i--)
                {
                    if(array[i].Equals(target))
                    {
                        return i;   
                    }
                }
                return -1;
            }

            //-----------Binary Search -------------
            int BinarySearch(int[] array, int target)
            {
                int left = 0;
                int right = array.Length - 1;

                int middle;
                while (left <= right)
                {
                    middle = (left + right) / 2;
                    switch (Compare(array[middle], target))
                    {
                        case -1: left = middle + 1; break;
                        case 0: return middle;
                        case 1: right = middle - 1; break;
                    }
                }
                return -1;
            }

            int Compare(int x, int y)
            {
                return x < y ? -1 : (y < x ? 1 : 0);
            }

            //---------------------------------------



            //usage examles-----------


            var array = new int[] { 0, 1, 5, 76, 234, 678 };

            var target = 76;
            var index = LinearSearch(array, target);
            Console.WriteLine($"Linear searching resuilt when target is {target} ---- index is:{index} ");
            index = BinarySearch(array, target);
            Console.WriteLine($"Binary searching resuilt when target is {target} ---- index is:{index}");
            Console.WriteLine("***********************************************************************");
            target = 75;
            index = LinearSearch(array, target);
            Console.WriteLine($"Linear searching resuilt when target is {target} ---- index is:{index}");
            index = BinarySearch(array, target);
            Console.WriteLine($"Binary searching resuilt when target is {target} ---- index is:{index}");
        }
    }
}