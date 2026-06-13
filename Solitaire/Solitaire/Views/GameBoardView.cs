using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solitaire.ConsoleUI.Views.PileViews;
using Solitaire.GameLogic.Services;
using Terminal.Gui;

namespace Solitaire.ConsoleUI.Views
{
    public class GameBoardView : Window
    {
        public GameManager GameManager { get; private set; }
        public List<FoundationPileView> FoundationList { get; private set; } = new List<FoundationPileView>();
        public List<TableauPileView> TableauList { get; private set; } = new List<TableauPileView>();
        public WastePileView DiscardPile { get; private set; }
        public DeckView Deck { get; private set; }
        public IEnumerable<PileView> AllPiles => TableauList.Cast<PileView>().Concat(FoundationList).Append(DiscardPile);

        public GameBoardView(GameManager gameManager)
        {
            this.GameManager = gameManager;
            CreateWindow();
            DrawDiscardPile();
            InitializeDeck();
            DrawFoundationPiles();
            DrawTableauPiles();
            DrawCardsOnAllTableaus();
        }

        private void CreateWindow()
        {
            Width = Dim.Fill();
            Height = Dim.Fill();
            ColorScheme = MyColorsToUse.BoardScheme;
        }

        private void DrawDiscardPile()
        {
            DiscardPile = new WastePileView(GameManager.DiscardPile)
            {
                X = Pos.Percent(15),
                Y = Pos.Percent(1)
            };
            DiscardPile.OnCardClickInPile += HandleCardClick;
            this.Add(DiscardPile);
        }

        private void InitializeDeck()
        {
            Deck = new DeckView(GameManager.CardDeck)
            {
                X = Pos.Percent(5),
                Y = Pos.Percent(1)
            };
            this.Add(Deck);
            Deck.OnDeckClick += HandleDeckClick;
        }

        private void DrawFoundationPiles()
        {
            var Xstep = -10;
            for (int i = 0; i < 4; i++)
            {
                Xstep += 10;
                var foundation = new FoundationPileView(GameManager.FoundationPiles[i])
                {
                    X = Pos.Percent(55 + Xstep),
                    Y = Pos.Percent(1)
                };
                FoundationList.Add(foundation);
                foundation.OnPileClick += HandlePileClick;
                foundation.OnCardClickInPile += HandleCardClick;
                this.Add(FoundationList[i]);
            }
        }

        private void DrawTableauPiles()
        {
            var Xstep = -10;
            for (int i = 0; i < 7; i++)
            {
                Xstep += 12;
                var tableau = new TableauPileView(GameManager.TableauPiles[i])
                {
                    X = Pos.Percent(7 + Xstep),
                    Y = Pos.Percent(25)
                };
                TableauList.Add(tableau);
                tableau.OnCardClickInPile += HandleCardClick;
                tableau.OnPileClick += HandlePileClick;
                this.Add(TableauList[i]);
            }
        }

        private void DrawCardsOnAllTableaus()
        {
            foreach (var tableau in TableauList)
            {
                tableau.DrawCards();
            }
        }

        private void HandleDeckClick(object? sender, EventArgs args)
        {
            if (sender is DeckView deck)
            {
                GameManager.MoveCardFromDeck();
                deck.DrawDeck();
                DiscardPile.DrawCards();
            }
        }

        private void HandleCardClick(object? sender, EventArgs args)
        {
            if (sender is CardView cardView && cardView.Card.IsFaceUp)
            {
                if (GameManager.SelectedCard == null)
                {
                    GameManager.SelectedCard = cardView.Card;
                    cardView.MakeHighLighted();
                }
                else
                {
                    var sourcePile = AllPiles.First(t => t.Pile.Stack.Contains(GameManager.SelectedCard));
                    var destinationPile = AllPiles.First(t => t.Pile.Stack.Contains(cardView.Card));
                    GameManager.TryToMove(sourcePile.Pile, destinationPile.Pile, cardView.Card);
                    sourcePile.DrawCards();
                    destinationPile.DrawCards();
                }
            }
        }

        private void HandlePileClick(object? sender, EventArgs args)
        {
            if (sender is PileView destinationPile)
            {
                if (GameManager.SelectedCard != null && destinationPile.Pile.Stack.Count == 0)
                {
                    var sourcePile = AllPiles.First(t => t.Pile.Stack.Contains(GameManager.SelectedCard));
                    GameManager.TryToMove(sourcePile.Pile, destinationPile.Pile, null);
                    sourcePile.DrawCards();
                    destinationPile.DrawCards();
                }
            }
        }
    }
}