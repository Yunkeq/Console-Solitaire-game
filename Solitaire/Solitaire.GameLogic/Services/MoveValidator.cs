using Solitaire.GameLogic.Enums;
using Solitaire.GameLogic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Services
{
    public static class MoveValidator
    {
        public static bool CanPlaceOnTableau(Card movingCard, Card? destinationCard)
        {
            if (destinationCard == null)
                return movingCard.Rank == CardRank.King;

            return movingCard.Rank == destinationCard.Rank - 1
                && movingCard.Color != destinationCard.Color;
        }

        public static bool CanPlaceOnFoundation(Card movingCard, Card? destinationCard)
        {
            if (destinationCard == null)
                return movingCard.Rank == CardRank.Ace;

            return movingCard.Rank == destinationCard.Rank + 1
                && movingCard.Suit == destinationCard.Suit;
        }
    }
}