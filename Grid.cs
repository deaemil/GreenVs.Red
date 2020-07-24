using System;
using System.Collections.Generic;
using System.Text;

namespace lifegame
{
    class Grid
    {
        private int col;
        private int row;
        private int[,] grid;
        private int x1;
        private int y1;
        private int generations;
        private int counter;

        
        public Grid()
        {
        }

        public Grid(int col, int row, int[,] grid, int x1, int y1, int generations)
        {
            this.col = col;
            this.row = row;
            this.grid = grid;
            this.x1 = x1;
            this.y1 = y1;
            this.generations = generations;
        }

        public int GetResult() {
            int result = 0;
           
           int count= MakeNGenerations(grid, generations);

            result = count;
            return result;
            
        }

        public int MakeNGenerations(int[,] firstArr, int n)
        {
            int sum = 0;
            counter = firstArr[y1, x1]; 
            int[,] secondArr=new int[row,col];
           //n- generations
            for(var g=0;g<n;g++)
            {
                // current cell
                for (var k = 0; k < row; k++)
                {

                    for (var l = 0; l < col; l++)
                    {
                        sum = 0;
                        //around cells
                        for (var j = k - 1; j <= k + 1; j++)
                        {
                            if (j >= 0 && j < row)
                            {
                                for (var i = l - 1; i <= l + 1; i++)
                                {
                                    if (i >= 0 && i < col)
                                    {
                                        sum += firstArr[j, i];
                                    }
                                }
                            }
                        }
                        //Checks for cell
                        if(firstArr[k,l]==1 )
                        {
                           sum -= firstArr[k, l];
                        }
                        if (sum == 3 || sum == 6 || (firstArr[k, l] == 1 && sum == 2))
                        {
                            secondArr[k, l] = 1;
                        }
                        else { secondArr[k, l] = 0; }

                        if (k == y1 && l == x1 && secondArr[k, l] == 1)
                        {
                            counter++;
                        }
                    }
                }

                int[,] arr = firstArr;
                firstArr = secondArr;
                secondArr = arr;             

            }

            return counter;
        }
        
       
    }
}
