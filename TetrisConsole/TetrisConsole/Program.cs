using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            Point p1 = new Point();
            p1.x = 2;
            p1.y = 3;
            p1.c = '*';
            p1.Draw();

            Console.ReadLine();
        }
    }
}