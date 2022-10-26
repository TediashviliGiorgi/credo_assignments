namespace binarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int BinarySearch(int[] array, int target)
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
            //usage examles-----------
            var array = new int[] { 0, 1, 5, 76, 234, 678 };

            var target = 76;
            var index = BinarySearch(array, target);
            Console.WriteLine(index);

            target = 75;
            index = BinarySearch(array, target);
            Console.WriteLine(index);
        }
    }
    
}