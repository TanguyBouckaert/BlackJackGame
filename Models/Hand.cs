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
            _cards.Add(blackJackCard);
        }

        public int CalculateValue()
        {
            int totaal = 0;

            foreach (BlackJackCard card in _cards)
            {
                totaal += card.Value;
            }

            return totaal;
        }

        public Hand()
        {

        }

        public void TurnAllCardsFaceUp()
        {
            foreach(BlackJackCard card in _cards)
            {
                card.TurnCard();
            }
        }
    }
}
