using Solitaire.GameLogic.Enums;
namespace Solitaire.GameLogic.Models
{
    public class Card
    {
        public CardRank Rank { get; private set; }
        public CardSuit Suit { get; private set; }
        public CardColor Color => Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds ? CardColor.Red : CardColor.Black;
        public bool IsFaceUp { get; set; } = false;

        public Card(CardRank rank, CardSuit suit, bool isFaceUp)
        {
            Rank = rank;
            Suit = suit;
            IsFaceUp = isFaceUp;
        }

        public void FaceUp()
        {
            IsFaceUp = true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Card other)
            {
                return Rank == other.Rank & Suit == other.Suit;
            }
            return false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 * Rank.GetHashCode();
                hash = hash * 23 * Suit.GetHashCode();
                hash = hash * 23 * Color.GetHashCode();
                hash = hash * 23 * IsFaceUp.GetHashCode();
                return hash;
            }
        }
    }
}

