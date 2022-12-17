namespace MoveElementToEnd
{
    public class Program
    {
        List<int> myList = new List<int>() {2, 1, 2, 2, 2, 3, 4, 2};
        public int toMove = 2;
        public void MoveElemetToEnd(int toMove)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if(myList[i] == toMove )
                {
                    myList.Add(myList[i]);
                    myList.Remove(myList[i]);
                }
                
            }
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
        
        public void Run()
        {
            MoveElemetToEnd(toMove);
        }

        static void Main(string[] args)
        {
            var MyInstance = new Program();
            MyInstance.Run();
        }
    }
}