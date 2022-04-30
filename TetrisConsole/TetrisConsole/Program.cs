using System;

namespace TetrisConsole
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.HEIGHT); //размер окна
            Console.SetBufferSize(Field.Width, Field.HEIGHT); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            Field.Width = 20;

            FigureGenerator generator = new FigureGenerator(Field.Width / 2 - 1, 0, '*');
            Figure currentFigure = generator.GetNewFigure();
            
            while(true)
            {
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(currentFigure, key);
                }
            }
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    currentFigure.TryRotate();
                    break;
            }
        }
    }
}