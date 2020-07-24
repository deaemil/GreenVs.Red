using System;

namespace lifegame
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Input
            //1.1. GameBoard size x,y
            
            Console.Write("board size:");
            string s = Console.ReadLine();
            string[] boardsize = s.Split(",");
            //width
            int x = Int32.Parse(boardsize[0]);
            //height
            int y = Int32.Parse(boardsize[1]);

            //1.2. Generation Zero
            Console.WriteLine("Generation Zero:");
            string[] gridValues= new string[y];
            for (var i =0; i<y; i++)
            {
                gridValues[i] = Console.ReadLine();
                if (gridValues[i].Length > x|| gridValues[i].Length<x)
                {
                    Console.WriteLine("wrong input");
                    return;
                }
            }
            char[] arrX = new char[x];
            int[,] gridArray = new int[y,x];
            for (var i=0; i < y; i++)
            {          
                  arrX =gridValues[i].ToCharArray();
         
                for(var j = 0; j < x; j++)
                {
                    gridArray[i, j] = arrX[j]-'0';
                }
            }

            //1.3 Coordinate and n generations
            Console.Write("Coordinates x1,y1 and number of generations:");
            string str = Console.ReadLine();
            string[] input = str.Split(",");
            int x1 = Int32.Parse(input[0]);
            int y1 = Int32.Parse(input[1]);
            int generations = Int32.Parse(input[2]);

            //2. 
            Grid grid = new Grid(x,y,gridArray,x1,y1,generations);

            //3.Output
            int result = grid.GetResult();
            Console.WriteLine(result);
        }
    }
}
