using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGui
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new GuiDrawer();

        public static IDrawer Drawer
        {
            get { return _drawer; }
        }
    }
}