using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = generator.GetNewFigure();
            
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Rotate();
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.DOWN);
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.RIGHT);
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Rotate();
            s.Draw();

            Console.ReadLine();
        }
    }
}