using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            Square s = new Square(2, 5, '*');
            s.Draw();

            //Point p1 = new Point(2, 3, '*');
            //p1.Draw();

            Console.ReadLine();
        }
    }
}