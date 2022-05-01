using System;

namespace TetrisConsole
{
    class Program
    {
        private static FigureGenerator? generator;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height); //размер окна
            Console.SetBufferSize(Field.Width, Field.Height); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки

            generator = new FigureGenerator(Field.Width / 2 - 1, 0, '*');
            Figure currentFigure = generator.GetNewFigure();
            
            while(true)
            {
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                }
            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static Result HandleKey(Figure f, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return f.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return f.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}