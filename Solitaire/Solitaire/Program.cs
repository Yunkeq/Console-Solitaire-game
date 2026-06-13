using Solitaire.ConsoleUI.Views;
using Solitaire.ConsoleUI.Views.PileViews;
using Solitaire.GameLogic;
using Solitaire.GameLogic.Enums;
using Solitaire.GameLogic.Models;
using Solitaire.GameLogic.Services;
using Terminal.Gui;
using static Terminal.Gui.View;

namespace Solitaire.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            Application.Init();

            var top = Application.Top;

            var gameManager = new GameManager();
            var gameBoard = new GameBoardView(gameManager);

            top.Add(gameBoard);

            Application.Run();
            Application.Shutdown();
        }
    }
}
