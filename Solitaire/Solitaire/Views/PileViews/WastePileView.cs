using Solitaire.GameLogic.Models.Piles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views.PileViews
{
    public class WastePileView : PileView
    {
        public WastePile DiscardPile { get; }

        public override Pile Pile => DiscardPile;

        public WastePileView(WastePile discardPile)
        {
            DiscardPile = discardPile;
        }

        public override void DrawCards()
        {
            if (DiscardPile.Stack.LastOrDefault() != null)
            {
                var cardView = new CardView(DiscardPile.Stack.LastOrDefault());
                this.Add(cardView); // the not-deleting is possible.(so view of deleted card is stil here)
                AtachCardClickEvents(cardView);
            }
            else
            {
                this.RemoveAll();
            }
        }
    }
}
