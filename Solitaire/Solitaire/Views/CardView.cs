using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Solitaire.GameLogic.Models;
using Solitaire.GameLogic.Enums;

namespace Solitaire.ConsoleUI.Views
{
    public class CardView : FixedWindow
    {
        public Card Card { get; }

        private readonly Label _rankView;
        private readonly Label _suitView;
        private readonly Label _faceDownView;
        public event EventHandler? OnCardClick;

        public CardView(Card card)
        {
            Card = card;
            Width = Dim.Fill();
            Height = Dim.Fill();
            ColorScheme = MyColorsToUse.FaceDownCardScheme;
            this.MouseClick += OnClick;
            _rankView = new Label()
            {
                X = Pos.Percent(0),
                Y = Pos.Percent(0),
                Text = GetRankString()
            };

            _suitView = new Label()
            {
                X = Pos.Percent(27),
                Y = Pos.Percent(0),
                Text = GetSuitUnicodde()
            };

            _faceDownView = new Label()
            {
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            UpdateView();
        }
        public void UpdateView()
        {
            RemoveAll();
            if (Card.IsFaceUp)
            {
                CanFocus = true;
                this.Border = new Border()
                {
                    BorderStyle = BorderStyle.Single,
                };
                ColorScheme = Card.Color == CardColor.Red ? MyColorsToUse.RedCardScheme : MyColorsToUse.BlackCardScheme;
                Add(_rankView, _suitView);
            }
            else
            {
                Add(_faceDownView);
            }
        }

        public void MakeHighLighted()
        {
            this.Border.BorderStyle = BorderStyle.Double;
        }

        private string GetSuitUnicodde()
        {
            return Card.Suit switch
            {
                CardSuit.Hearts => "♥️",
                CardSuit.Diamonds => "♦️",
                CardSuit.Clubs => "♣️",
                CardSuit.Spades => "♠️",
                _ => "?",
            };
        }

        private string GetRankString()
        {
            return Card.Rank switch // switch expression
            {
                CardRank.Two => "2",
                CardRank.Three => "3",
                CardRank.Four => "4",
                CardRank.Five => "5",
                CardRank.Six => "6",
                CardRank.Seven => "7",
                CardRank.Eight => "8",
                CardRank.Nine => "9",
                CardRank.Ten => "10",
                CardRank.Jack => "J",
                CardRank.Queen => "Q",
                CardRank.King => "K",
                CardRank.Ace => "A",
                _ => "?"
            };
        }

        private void OnClick(MouseEventArgs args)
        {
            if (args.MouseEvent.Flags.HasFlag(MouseFlags.Button1Clicked))
            {
                OnCardClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
