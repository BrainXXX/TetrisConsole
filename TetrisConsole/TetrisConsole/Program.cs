using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CA1416 // Проверка совместимости платформы
            Console.SetWindowSize(40, 30); //размер окна
            Console.SetBufferSize(40, 30); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
#pragma warning restore CA1416 // Проверка совместимости платформы

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s;
            
            while(true)
            {
                FigureFall(out s, generator);
                s.Draw();
            }

            static void FigureFall(out Figure fig, FigureGenerator generator)
            {
                fig = generator.GetNewFigure();
                fig.Draw();

                for (int i = 0; i < 15; i++)
                {
                    fig.Hide();
                    fig.Move(Direction.DOWN);
                    fig.Draw();
                    Thread.Sleep(200);
                }
            }
        }
    }
}