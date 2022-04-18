using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            int x1 = 2;
            int y1 = 3;
            char c1 = '*';

            Drow(x1, y1, c1);

            Console.ReadLine();
        }

        static void Drow(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}