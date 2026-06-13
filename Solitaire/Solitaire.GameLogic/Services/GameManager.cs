using Solitaire.GameLogic.Models;
using Solitaire.GameLogic.Models.Piles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Services
{
    public class GameManager
    {
        public Card? SelectedCard { get; set; }
        public List<TableauPile> TableauPiles { get; private set; } = new List<TableauPile>();
        public List<FoundationPile> FoundationPiles { get; private set; } = new List<FoundationPile>();
        public WastePile DiscardPile { get; set; }
        public Deck CardDeck { get; private set; }

        public GameManager()
        {
            DiscardPile = new WastePile();
            CardDeck = new Deck();
            CreateFoundationPiles();
            InitializeTableauPiles();
        }

        public void SelectCard(Card card)
        {
            SelectedCard = card;
        }

        public void TryToMove(Pile sourcePile, Pile destinationPile, Card? destinationCard)
        {
            if (sourcePile is ICanRetriveCardFrom pileToRetrieve && destinationPile is not WastePile)
            {
                ICanRevealLastCard? source = sourcePile as ICanRevealLastCard;
                if (destinationPile is TableauPile tableau && MoveValidator.CanPlaceOnTableau(SelectedCard, destinationCard))
                {
                    if (pileToRetrieve.IsTopCard(SelectedCard))
                    {
                        MoveSingleCard(pileToRetrieve, tableau);
                    }
                    else
                    {
                        MoveCardStack((TableauPile)pileToRetrieve, tableau);
                    }
                    source?.MakeLastCardFaceUp();
                }
                else if (destinationPile is FoundationPile foundation && MoveValidator.CanPlaceOnFoundation(SelectedCard, destinationCard) && sourcePile.LastCard == SelectedCard)
                {
                    MoveSingleCard(pileToRetrieve, foundation);
                    source?.MakeLastCardFaceUp();
                }
            }
            SelectedCard = null;
        }

        public void MoveCardFromDeck()
        {
            if (CardDeck.Cards.Count != 0)
            {
                DiscardPile.AddCard(CardDeck.RetrieveCard());
                DiscardPile.MakeLastCardFaceUp();
            }
            else
            {
                CardDeck.AcceptCardList(DiscardPile.RetrieveAllCards());
            }
        }

        private void CreateFoundationPiles()
        {
            for (int i = 0; i < 4; i++)
            {
                FoundationPiles.Add(new FoundationPile());
            }
        }

        private void InitializeTableauPiles()
        {
            for (int i = 0; i < 7; i++)
            {
                TableauPiles.Add(new TableauPile());
                for (int j = 0; j <= i; j++)
                {
                    TableauPiles[i].AddCard(CardDeck.RetrieveCard());
                }
                TableauPiles[i].MakeLastCardFaceUp();
            }
        }

        private void MoveSingleCard(ICanRetriveCardFrom source, Pile destination)
        {
            source.RemoveLastCard();
            destination.AddCard(SelectedCard);
        }

        private void MoveCardStack(TableauPile tableauSource, TableauPile tableauDestination)
        {
            var cardsToReplace = tableauSource.GetCardsFrom(SelectedCard);
            tableauSource.RemoveCardListFrom(SelectedCard);
            tableauDestination.AddCardList(cardsToReplace);
        }
    }
}