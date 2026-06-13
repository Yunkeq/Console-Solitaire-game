using Solitaire.GameLogic.Models.Piles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views.PileViews
{
    public abstract class PileView : FixedWindow
    {
        public abstract Pile Pile { get; }
        public event EventHandler? OnPileClick;
        public event EventHandler? OnCardClickInPile;
        public PileView()
        {
            Width = Dim.Percent(8);
            Height = Dim.Percent(23);
            Border = new Border()
            {
                BorderStyle = BorderStyle.Single,
            };
            ColorScheme = null;
            this.MouseClick += OnClick;
        }

        protected void AtachCardClickEvents(CardView cardView)
        {
            cardView.OnCardClick += OnCardClickInPile;
        }

        public abstract void DrawCards();

        private void OnClick(MouseEventArgs args)
        {
            if (args.MouseEvent.Flags.HasFlag(MouseFlags.Button1Clicked))
            {
                OnPileClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
