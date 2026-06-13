using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Models.Piles
{
    public class WastePile : Pile, ICanRetriveCardFrom, ICanRevealLastCard
    {
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

        public List<Card> RetrieveAllCards()
        {
            var cards = new List<Card>(Stack);
            Stack.Clear();
            return cards;
        }

        public void MakeLastCardFaceUp()
        {
            if (Stack.Count > 0 && !Stack.Last().IsFaceUp)
                Stack.Last().FaceUp();
        }
    }
}