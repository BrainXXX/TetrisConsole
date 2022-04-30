using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisConsole
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
    static class Field
    {
        private static int _width = 40;
        private static int _height = 30;

        public static int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                Console.SetWindowSize(value, Height); //размер окна
                Console.SetBufferSize(value, Height); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
            }
        }

        public static int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                Console.SetWindowSize(Width, value); //размер окна
                Console.SetBufferSize(Width, value); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
            }
        }

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];

            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void AddFigure(Figure fig)
        {
            foreach(var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }
    }
}