using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    class Deck
    {
        private readonly Random random;
        private readonly IList<BlackJackCard> _cards;
        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach(var faceValue in Enum.GetValues(typeof(FaceValue)))
                foreach(var suit in Enum.GetValues(typeof(Suit)))
                    _cards.Add(new BlackJackCard((Suit)suit, (FaceValue)faceValue));
        }

        public BlackJackCard Draw()
        {
            if(0 != _cards.Count)
            {
                BlackJackCard card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            else
            {
                throw new InvalidOperationException("Er zijn geen kaarten meer.");
            }
            
        }

        private void Shuffle()
        {
            List<BlackJackCard> hulp = new List<BlackJackCard>();
        }
    }
}
