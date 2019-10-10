using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
     public class Hand
    {

        private IList<BlackJackCard> _cards;

        public IEnumerable<BlackJackCard> Cards { get; }
        public int NrOfCards { get; }
        public int Value { get; }

        public void AddCard(BlackJackCard blackJackCard)
        {

        }

        public int CalculateValue()
        {

        }

        public Hand()
        {

        }

        public void TurnAllCardsFaceUp()
        {

        }
    }
}
