using Solitaire.GameLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Models.Piles
{
    public abstract class Pile
    {
        public List<Card> Stack { get; private set; } = new List<Card>();
        public Card? LastCard => Stack.LastOrDefault();

        public void AddCard(Card card)
        {
            Stack.Add(card);
        }
    }
}