﻿using System;

namespace TetrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CA1416 // Проверка совместимости платформы
            Console.SetWindowSize(Field.WIDTH, Field.HEIGHT); //размер окна
            Console.SetBufferSize(Field.WIDTH, Field.HEIGHT); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
#pragma warning restore CA1416 // Проверка совместимости платформы

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
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