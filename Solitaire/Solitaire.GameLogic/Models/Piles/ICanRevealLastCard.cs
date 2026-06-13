using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.GameLogic.Models.Piles
{
    public interface ICanRevealLastCard
    {
        public void MakeLastCardFaceUp();
    }
}
