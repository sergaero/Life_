using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{

    class Marix
    {
        //ПОЛЯ
        const int m = 20;   //размер поля жизни
        const int n = 20;
        public byte[,] pole;       //двумерный массив из нулей и единиц
       
        //СВОЙСТВА
        public int M { get { return m; }}       //столбцы

        public int N { get { return n; } }      //строки

        //КОНСТРУКТОРЫ

        
        public Marix()
        {
            pole = new byte[m, n];
            //pole[m-1, n-1] = 0;
            
            for (int col = 0; col <= m-1; col++)
            {
                for (int row = 0; row <= n-1; row++)
                {
                    pole[col, row] = 0;
                }
            }
            //начальное состояние системы
            
            pole[3, 5] = 1;
            pole[3, 6] = 1;
            pole[4, 7] = 1;
            pole[2, 5] = 1;
            pole[0, 9] = 1;
            pole[2, 19] = 1;
            pole[3, 19] = 1;
            pole[3, 10] = 1; 

            //глайдер
            pole[0, 2] = 1;
            pole[1, 0] = 1;
            pole[1, 2] = 1;
            pole[2, 1] = 1;
            pole[2, 2] = 1;
            
            //бокен
            pole[13, 10] = 1;
            pole[14, 10] = 1;
            pole[13, 11] = 1;
            pole[14, 11] = 1;
            pole[11, 12] = 1;
            pole[12, 12] = 1;
            pole[11, 13] = 1;
            pole[12, 13] = 1;
            pole[14, 14] = 1;
        }
        

        //МЕТОДЫ
        public int CountZhiv(byte[,] p, int m, int n)
        {
            //метод считает количество живых клеток вокруг клетки m:n
            int sum = 0;
            if (m >= 0 && m <= M-1 && n >= 0 && n <= N-1)
            {
                int coll= m;
                int roww = n;
                int collMinus = coll - 1;
                int rowwMinus = roww - 1;
                int collPlus = coll + 1;
                int rowwPlus = roww + 1;
                if (collMinus < 0) collMinus = M-1;
                if (rowwMinus < 0) rowwMinus = N-1;
                if (collPlus > M-1) collPlus = 0;
                if (rowwPlus > N-1) rowwPlus = 0;

                //считаем в той же строке
                if (p[collMinus, roww] == 1) { sum++; }
                if (p[collPlus,  roww] == 1) { sum++; }
                //считаем на строку выше
                if (p[collMinus, rowwMinus] == 1) { sum++; }
                if (p[coll,      rowwMinus] == 1) { sum++; }
                if (p[collPlus,  rowwMinus] == 1) { sum++; }
                //считаем на строку ниже
                if (p[collMinus, rowwPlus] == 1) { sum++; }
                if (p[coll,      rowwPlus] == 1) { sum++; }
                if (p[collPlus,  rowwPlus] == 1) { sum++; }
            }
            else
            {
                Console.WriteLine($"Размер матрицы {M} на {N}. Соответственно, диапазон индексов {M-1} и {N-1}. Вы ввели слишком большие значения.");
            }
            return sum;
        }

        public byte[,] Iteration(ref byte[,] _p, out byte[,] out_p)
        {

            //метод совершает одну итерацию, изменяя матрицу согласно правилам игры "Жизнь"
            int s;  //сумма живых клеток вокруг данной клетки
            for (int x = 0; x < M; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    //если сама клетка живая
                    if (_p[x, y] == 1)
                    {
                        //если сумма живых клеток вокруг данной ячейки меньше двух или больше трёх то клетка = 0
                        s = CountZhiv(_p, x, y);
                        if (s < 2 || s > 3) _p[x, y] = 0;
                    }

                    //если сама клетка неживая
                    if (_p[x,y] == 0)
                    {
                        //если сумма живых клеток вокруг данной ячейки = 3 клетка становится живой
                        s = CountZhiv(_p, x, y);
                        if (s == 3) _p[x, y] = 1;
                    }
                  
                }
            }
            out_p = _p;
            return out_p;
        }

    }
}
