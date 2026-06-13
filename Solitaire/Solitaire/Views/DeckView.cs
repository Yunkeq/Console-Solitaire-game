using Solitaire.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views
{
    public class DeckView : FixedWindow
    {
        public Deck CardDeck { get; }
        public event EventHandler? OnDeckClick;

        public DeckView(Deck deck)
        {
            Border = new Border()
            {
                BorderStyle = BorderStyle.Single,
            };
            CardDeck = deck;
            Width = Dim.Percent(8);
            Height = Dim.Percent(23);
            CanFocus = true;
            this.MouseClick += OnClick;
            DrawDeck();
        }

        public void DrawDeck()
        {
            this.RemoveAll();
            var lastCard = CardDeck.Cards.LastOrDefault();
            if (lastCard is not null)
            {
                ColorScheme = MyColorsToUse.FaceDownCardScheme;
            }
            else
            {
                ColorScheme = null;
            }
        }   

        private void OnClick(MouseEventArgs args)
        {
            if (args.MouseEvent.Flags.HasFlag(MouseFlags.Button1Clicked))
            {
                //MessageBox.Query(20, 7, "Click", "Deck clicked!", "OK");
                OnDeckClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
