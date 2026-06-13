using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI
{
    public static class MyColorsToUse
    {
        public static ColorScheme BoardScheme { get; } = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Gray, Color.Green),
            Focus = Application.Driver.MakeAttribute(Color.White, Color.Blue),
            HotNormal = Application.Driver.MakeAttribute(Color.Black, Color.White),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };

        public static ColorScheme RedCardScheme { get; } = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Red, Color.Gray),
            Focus = Application.Driver.MakeAttribute(Color.Red, Color.Blue),
            HotNormal = Application.Driver.MakeAttribute(Color.Black, Color.White),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };

        public static ColorScheme BlackCardScheme { get; } = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Black, Color.Gray),
            Focus = Application.Driver.MakeAttribute(Color.Red, Color.Blue),
            HotNormal = Application.Driver.MakeAttribute(Color.Black, Color.White),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };

        public static ColorScheme FaceDownCardScheme { get; } = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.White, Color.Red),
            Focus = Application.Driver.MakeAttribute(Color.Red, Color.Blue),
            HotNormal = Application.Driver.MakeAttribute(Color.Black, Color.White),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };
    }
}