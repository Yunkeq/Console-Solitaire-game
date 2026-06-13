using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views
{
    public class FixedWindow : Window
    {
        public override bool OnMouseEvent(MouseEvent me)
        {
            if (me.Flags.HasFlag(MouseFlags.Button1Pressed))
            {
                if (me.Y == 0)
                    return true;
            }

            return base.OnMouseEvent(me);
        }
    }
}
