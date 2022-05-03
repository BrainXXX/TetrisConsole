﻿using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace TetrisGui
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();

        static Figure currentFigure;
        static FigureGenerator generator;

        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();

            generator = new FigureGenerator(Field.Width / 2 - 1, 0);
            currentFigure = generator.GetNewFigure();

            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;

            //SetTimer();

            //while (true)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        var key = Console.ReadKey();
            //        Monitor.Enter(_lockObject);
            //        var result = HandleKey(currentFigure, key.Key);
            //        ProcessResult(result, ref currentFigure);
            //        Monitor.Exit(_lockObject);
            //    }
            //}

            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.FontSize = 20;
            GraphicsWindow.DrawText(10, 10, "Game Over");
        }

        private static void GraphicsWindow_KeyDown()
        {
            String lastKey = (String)GraphicsWindow.LastKey;
            switch(lastKey)
            {
                case "Left":
                    currentFigure.TryMove(Direction.LEFT);
                    break;
            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
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

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }
    }
}