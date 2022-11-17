using System.Linq.Expressions;

namespace ConsoleTicTacToe;

class Program
{
    static int currentPlayer = 1;

    static char[][] boardStateArr = new char[][]
          {
                new char[] { 'A', 'B', 'C', },
                new char[] { 'D', 'E', 'F', },
                new char[] { 'G', 'H', 'I', }
          };

    public static char GetCorrectSimbolAccordingPlayer(int currentPlayer)
    {
        // get X or 0
        if (currentPlayer == 1)
        {
            return 'X';

        }
        else
        {
            return '0';
        }
    }

    public static int CheckWin(int currentPlayer, char[][] boardStateArr)
    {
        //diagonal wining condition--------------------------------------
        if (boardStateArr[0][0] == boardStateArr[1][1] && boardStateArr[1][1] == boardStateArr[2][2])
        {
            return 1;
        }
        else if (boardStateArr[2][0] == boardStateArr[1][1] && boardStateArr[1][1] == boardStateArr[0][2])
        {
            return 1;
        }
        //horizontal wining condition-------------------------------------
        else if(boardStateArr[0][0] == boardStateArr[0][1] && boardStateArr[0][1] == boardStateArr[0][2])
        {
            return 1;
        }else if(boardStateArr[1][0] == boardStateArr[1][1] && boardStateArr[1][1] == boardStateArr[1][2])
        {
            return 1;
        }
        else if (boardStateArr[2][0] == boardStateArr[2][1] && boardStateArr[2][1] == boardStateArr[2][2])
        {
            return 1;
        }
        //vertical wining condition----------------------------------------
        else if (boardStateArr[0][0] == boardStateArr[1][0] && boardStateArr[1][0] == boardStateArr[2][0])
        {
            return 1;
        }
        else if (boardStateArr[0][1] == boardStateArr[1][1] && boardStateArr[1][1] == boardStateArr[2][1])
        {
            return 1;
        }
        else if (boardStateArr[0][2] == boardStateArr[1][2] && boardStateArr[1][2] == boardStateArr[2][2])
        {
            return 1;
        }
        else if(boardStateArr[0][0] != 'A' && boardStateArr[0][1] != 'B' && boardStateArr[0][2] != 'C' && boardStateArr[1][0] != 'D' && boardStateArr[1][1] != 'E' && boardStateArr[1][2] != 'F' && boardStateArr[2][0] != 'G' && boardStateArr[2][1] != 'H' && boardStateArr[2][2] != 'I')
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public static void BoardState(int coordinateX, int coordinateY)
    {
        Console.Clear();
        char symbol;

        // check box if empty add simbol in to array and toggle player -------------------------
        if (boardStateArr[coordinateX][coordinateY] != '0' && boardStateArr[coordinateX][coordinateY] != 'X')
        {
            if (currentPlayer == 1)
            {

                symbol = GetCorrectSimbolAccordingPlayer(currentPlayer);
                boardStateArr[coordinateX][coordinateY] = symbol;
                currentPlayer = 2;
            }
            else
            {
                symbol = GetCorrectSimbolAccordingPlayer(currentPlayer);
                boardStateArr[coordinateX][coordinateY] = symbol;
                currentPlayer = 1;
            }
        }
        else
        {
            Console.WriteLine("Space is not empty: please select correct coordinates");
        }

        //--------------------------------------------------------------------

        //get table with current state ---------------------------------------
        Console.WriteLine("Player 1 plaining as X");
        Console.WriteLine("Player 2 plaining as 0");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[0][0]}  |  {boardStateArr[0][1]}  |  {boardStateArr[0][2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[1][0]}  |  {boardStateArr[1][1]}  |  {boardStateArr[1][2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[2][0]}  |  {boardStateArr[2][1]}  |  {boardStateArr[2][2]}");
        Console.WriteLine("     |     |      ");
        //--------------------------------------------------------------------
    }

    static void Main(string[] args)
    {
        //table first look
        Console.WriteLine("Player 1 plaining as X");
        Console.WriteLine("Player 2 plaining as 0");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[0][0]}  |  {boardStateArr[0][1]}  |  {boardStateArr[0][2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[1][0]}  |  {boardStateArr[1][1]}  |  {boardStateArr[1][2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {boardStateArr[2][0]}  |  {boardStateArr[2][1]}  |  {boardStateArr[2][2]}");
        Console.WriteLine("     |     |      ");
        bool gameFlow = true;
        do
        {
            //get and validate coordinates-------------------------------------
            Console.Write($"Enter player{currentPlayer} position(x y): ");
            string[]? input = Console.ReadLine().Split(' ');
            try
            {
                int coordinateX = Convert.ToInt32(input[0]);
                int coordinateY = Convert.ToInt32(input[1]);

                BoardState(coordinateX, coordinateY);
            //------------------------------------------------------------------

                //game ends-----------------------------------------------------
                int gameResult = CheckWin(currentPlayer, boardStateArr);
                if (gameResult == 1 && currentPlayer == 2)
                {
                    currentPlayer--;
                    Console.WriteLine($"Congrats! player: {currentPlayer} Won!");
                    gameFlow = false;
                }else if (gameResult == 1 && currentPlayer == 1)
                {
                    currentPlayer++;
                    Console.WriteLine($"Congrats! player: {currentPlayer} Won!");
                    gameFlow = false;
                } else if(gameResult == 0)
                {
                    Console.WriteLine("Draw!");
                }else
                {
                    Console.WriteLine();
                }
                //------------------------------------------------------------------
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please set correct coordinates and use space between them");
                continue;
            }
        } while (gameFlow == true);
    }
}



