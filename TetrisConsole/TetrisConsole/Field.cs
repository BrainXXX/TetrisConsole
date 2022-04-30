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
                Console.SetWindowSize(_width, Field.HEIGHT); //размер окна
                Console.SetBufferSize(_width, Field.HEIGHT); //уменьшаем зону буфера текста, чтобы скрыть полосы прокрутки
            }
        }

        private static int _width = 40;
        public const int HEIGHT = 30;
    }
}