using Solitaire.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Models
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public Deck()
        {
            Initialize();
            Shuffle();
        }

        public Card RetrieveCard()
        {
            var topCard = Cards.Last();
            Cards.Remove(topCard);
            return topCard;
        }

        public void AcceptCardList(List<Card> cards)
        {
            Cards.AddRange(cards);
        }

        private void Initialize()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    Cards.Add(new Card(rank, suit, false));
                }
            }
        }

        private void Shuffle()
        {
            var random = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                var k = random.Next(i + 1);
                var value = Cards[k];
                Cards[k] = Cards[i];
                Cards[i] = value;
            }
        }
    }
}