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
            Console.WriteLine("Enter the number of lines: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns: ");
            int M = Convert.ToInt32(Console.ReadLine());
            int[,] cell = new int[N + 2, M + 2];
            int[,] cell2 = new int[N + 2, M + 2];
            Random random = new Random();
            
            int count = 0;

            for (int i = 1; i <= N; i++)         //задается основное поле
            {
                for (int j = 1; j <= M; j++)
                {
                    cell[i, j] = random.Next(0, 2);
                    Console.Write(cell[i, j]);
                }
                Console.WriteLine(' ');
            }
            for (int i = 1; i <= 2; i++)               //задаются границы поля (пояс значений равных нулю)
            {
                for (int j = 0; j <= M + 1; j++)
                {
                    cell[i, 0] = 0;
                }
            }
            for (int i = N; i <= N + 1; i++)
            {
                for (int j = 0; j <= M + 1; j++)
                {
                    cell[i, 0] = 0;
                }
            }
            for (int j = M; j <= M + 1; j++)
            {
                for (int i = 0; i <= N + 1; i++)
                {
                    cell[0, j] = 0;
                }
            }
            for (int j = 0; j <= 1; j++)
            {
                for (int i = 0; i <= N + 1; i++)
                {
                    cell[0, j] = 0;
                }
            }
            while (count < 1000)
            {
                int countlivingcells = 0;
                int countidentical = 0;
                count += 1;
                for (int i = 1; i <= N; i++)               //переход от одной клетки к другой
                {
                    for (int j = 1; j <= M; j++)
                    {
                        int countone = 0;                          //проверка соседей клетки
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
                        if (countone > 0)
                            countlivingcells += 1;

                        if (cell[i, j] == 1 && (countone < 2 | countone > 3))          //выстраивание вторичного поля
                            cell2[i, j] = 0;
                        else if (cell[i, j] == 1 && (countone == 3 | countone == 2))
                            cell2[i, j] = 1;
                        else if (cell[i, j] == 0 && countone == 3)
                            cell2[i, j] = 1;
                        else if (cell[i, j] == 0 && (countone > 3 | countone < 3))
                            cell2[i, j] = 0;
                    }
                }

                Console.WriteLine('.');             //вывод вторичного поля
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= M; j++)
                    {
                        Console.Write(cell2[i, j]);
                    }
                    Console.WriteLine(' ');
                }

                if (countlivingcells == 0)          //выход, если все клетки мертвы
                    goto S;

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= M; j++)
                    {
                        if (cell[i, j] == cell2[i, j])
                            countidentical += 1;
                    }
                }
                if (countidentical == N * M)          //выход, если предыдущая итерация одинакова с текущей
                    goto S;

                for (int i = 1; i <= N; i++)       //переопределяем изначальное поле
                {
                    for (int j = 1; j <= M; j++)
                    {
                        cell[i, j] = cell2[i, j];
                    }
                }

            }
            S: Console.WriteLine("End");
        }
    }
}