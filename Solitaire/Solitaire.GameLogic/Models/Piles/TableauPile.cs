using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solitaire.GameLogic.Enums;

namespace Solitaire.GameLogic.Models.Piles
{
    public class TableauPile : Pile, ICanRetriveCardFrom, ICanRevealLastCard
    {
        public void AddCardList(List<Card> cardList)
        {
            Stack.AddRange(cardList);
        }

        public void RemoveCardListFrom(Card startCard)
        {
            var index = Stack.IndexOf(startCard);
            Stack.RemoveRange(index, Stack.Count - index);
        }

        public void RemoveLastCard()
        {
            if (LastCard != null)
            {
                Stack.Remove(LastCard);
            }
        }

        public bool IsTopCard(Card card)
        {
            return Stack.Last() == card;
        }

        public List<Card> GetCardsFrom(Card startCard)
        {
            var index = Stack.IndexOf(startCard);
            if (index == -1)
                throw new Exception();
            return Stack.Skip(index).ToList();
        }

        public void MakeLastCardFaceUp()
        {
            if (Stack.Count > 0 && !Stack.Last().IsFaceUp)
                Stack.Last().FaceUp();
        }
    }
}
