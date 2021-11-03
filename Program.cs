using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            int M = 10;
            int[,] cell = new int[N, M];
            int[,] cell2 = new int[N, M];
            Random random = new Random();
            for (int i = 1; i <= N - 2; i++)
            {
                for (int j = 1; j <= M - 2; j++)
                {
                    cell[i, j] = random.Next(0, 2);
                    Console.Write(cell[i, j]);
                }
                Console.WriteLine(' ');
            }
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j <= M - 1; j++)
                {
                    cell[i, 0] = 0;
                }    
            }
            for (int i = N-2; i <= N-1; i++)
            {
                for (int j = 0; j <= M - 1; j++)
                {
                    cell[i, 0] = 0;
                }
            }
            for (int j = M - 2; j <= M-1; j++)
            {
                for (int i = 0; i <= N - 1; i++)
                {
                    cell[0, j] = 0;
                }            
            }
            for (int j = 0; j <= 1; j++)
            {
                for (int i = 0; i <= N - 1; i++)
                {
                    cell[0, j] = 0;
                }
            }

            for (int i = 1; i <= N -2; i++)
            {
                for (int j = 1; j <= M - 2; j++)
                {
                    int countone = 0;
                    if (cell[i, j + 1] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i, j - 1] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i + 1, j] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i - 1, j] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i + 1, j + 1] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i + 1, j - 1] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i - 1, j + 1] == 1)
                    {
                        countone += 1;
                    }
                    if (cell[i - 1, j - 1] == 1)
                    {
                        countone += 1;
                    }


                    if (cell[i, j] == 1 && (countone < 2 | countone > 3))
                        cell2[i, j] = 0;
                    else if(cell[i, j] == 1 && countone == 3) 
                        cell2[i, j] = 1;
                    else if (cell[i, j] == 0 && countone == 3)
                        cell2[i, j] = 1;
                    else if (cell[i, j] == 0 && (countone > 3 | countone < 3))
                        cell2[i, j] = 0;
                }
            }
            Console.WriteLine('.');
            for (int i = 1; i <= N - 2; i++)
            {
                for (int j = 1; j <= M - 2; j++)
                {
                    Console.Write(cell2[i, j]);
                }
                Console.WriteLine(' ');
            }

        }
    }
}