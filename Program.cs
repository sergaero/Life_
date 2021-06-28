using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{


    class Program
    {
        public static void VivodMatrix(Marix matrix)
        {
            Console.Clear();
            #region Обратный вывод
            /* for (int col = 0; col < matrix.M; col++)
             {
                 for (int row = 0; row < matrix.N; row++)
                 {
                     //System.Threading.Thread.Sleep(100);
                     Console.Write($"{matrix.pole[col, row]} ");
                 }
                 Console.WriteLine();
             } */
            #endregion

            for (int row = 0; row < matrix.N; row++)
            {
                for (int col = 0; col < matrix.M; col++)
                {
                    if (matrix.pole[col, row] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{matrix.pole[col, row]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{matrix.pole[col, row]} ");
                    }
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Marix m = new Marix();
            VivodMatrix(m);
            /*
            int x, y;
            Console.WriteLine();
            Console.WriteLine("Введите координаты X клетки:");
            var col = Console.ReadLine();
            Console.WriteLine("Введите координаты Y клетки:");
            var row = Console.ReadLine();
            if ((int.TryParse(col, out x)) && (int.TryParse(row, out y))) {
                int s = m.CountZhiv(m.pole, x, y);
                Console.WriteLine($"Сумма вокруг клетки = {s}");
            }
            */
            for (int i = 0; i < 1000; i++)
            {
                System.Threading.Thread.Sleep(250);
                m.pole = m.Iteration(ref m.pole, out _);
                VivodMatrix(m);
                Console.WriteLine();
                Console.WriteLine($"Итерация номер: {i}");
            }
            

            Console.ReadKey();
        }
    }
}
