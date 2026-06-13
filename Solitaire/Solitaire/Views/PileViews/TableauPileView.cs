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
    public class TableauPileView : PileView
    {
        public TableauPile Tableau { get; }
        public override Pile Pile => Tableau;

        public TableauPileView(TableauPile tableau)
        {
            Tableau = tableau;
            Height = Dim.Fill();
            Border = new Border() { BorderStyle = BorderStyle.None };
        }

        public override void DrawCards()
        {
            this.RemoveAll();
            var YPos = 0;
            foreach (var card in Tableau.Stack)
            {
                var cardView = new CardView(card)
                {
                    Height = Dim.Percent(30.7f), // 30.7 because 23 units of 65 units => (23 / 65) * 100 = 30.7
                    X = 0,
                    Y = Pos.Percent(YPos)
                };
                this.Add(cardView);
                AtachCardClickEvents(cardView);
                YPos += 5;
            }
        }
    }
}
