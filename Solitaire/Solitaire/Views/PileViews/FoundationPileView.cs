using Solitaire.GameLogic.Models;
using Solitaire.GameLogic.Models.Piles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views.PileViews
{
    public class FoundationPileView : PileView
    {
        public FoundationPile Foundation { get; }

        public override Pile Pile => Foundation;

        public FoundationPileView(FoundationPile foundation)
        {
            Foundation = foundation;
        }

        public override void DrawCards()
        {
            var card = Foundation.Stack.LastOrDefault();
            if (card == null) return;

            if (!Subviews.OfType<CardView>().Any(v => v.Card == card))
            {
                var cardView = new CardView(card);
                Add(cardView);
                AtachCardClickEvents(cardView);
            }
        }
    }
}
