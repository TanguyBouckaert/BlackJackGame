using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class Deck
    {
        private readonly Random _random = new Random();
        protected IList<BlackJackCard> _cards;
        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach(FaceValue f in Enum.GetValues(typeof(FaceValue))) 
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    _cards.Add(new BlackJackCard(s, f));
                }
            Shuffle();//Tanguy: no methode shuffle added
        }

        
        private void Shuffle()
        {
            /*List<BlackJackCard> hulp = new List<BlackJackCard>();
            
            foreach(BlackJackCard card in _cards)
            {
                hulp.Insert(_random.Next(1,10), card);
            }
            int teller = 0;
            foreach(BlackJackCard card in hulp)
            {
                _cards.Insert(teller, card);
                teller++;
            }*/
            //Methode hierboven veel te moeilijk geschreven 

            for(int i = 1; i < _cards.Count * 3; i++)
            {
                int randomPosition = _random.Next(0, _cards.Count);
                BlackJackCard card = _cards[randomPosition];
                _cards.RemoveAt(randomPosition);
                _cards.Add(card);
            }
        }

        public BlackJackCard Draw()//Methode is juist maar anders dan oplossing
        {
            if (0 != _cards.Count)
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

    }
}
