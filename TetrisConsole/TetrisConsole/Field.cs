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
        public static int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                Console.SetWindowSize(_width, _height); //размер окна
                Console.SetBufferSize(_width, _height); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
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
                Console.SetWindowSize(_width, _height); //размер окна
                Console.SetBufferSize(_width, _height); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
            }
        }

        private static int _width = 40;
        private static int _height = 30;
    }
}