using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            Figure[] f = new Figure[2];
            f[0] = new Square(2, 5, '*');
            f[1] = new Stick(6, 6, '*');

            foreach (Figure fig in f)
            {
                fig.Draw();
            }

            Console.ReadLine();
        }
    }
}