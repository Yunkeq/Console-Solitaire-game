using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Models.Piles
{
    interface ICanRetriveCardFrom
    {
        public void RemoveLastCard();

        public bool IsTopCard(Card card);
    }
}
