using System.Collections.Generic;
using System.Linq;

namespace BlackJackGame.Models
{
    public class Hand
    {

        private IList<BlackJackCard> _cards;

        public IEnumerable<BlackJackCard> Cards { get { return _cards; } }//get niet goed genoeg uitgewerkt
        public int NrOfCards { get { return Cards.Count(); } }//get niet goed genoeg uitgewerkt
        public int Value { get { return CalculateValue(); } }//get niet goed genoeg uitgewerkt

        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
        }

        public int CalculateValue()
        {//bool vergeten voor als er een ace is (ace is 11 of 1)
            int totaal = 0;
            bool ace = false;

            foreach (BlackJackCard card in Cards)
            {
                totaal += card.Value;
                if (card.FaceUp && card.FaceValue == FaceValue.Ace)
                    ace = true;
            }
            if (ace && (totaal + 10) <= 21)
                totaal += 10;
            return totaal;
        }

        public Hand()
        {//Was leeg moet ingevuld zijn!!!!!!!
            _cards = new List<BlackJackCard>();
        }

        public void TurnAllCardsFaceUp()
        {
            foreach (BlackJackCard card in Cards)
            {
                if(!card.FaceUp)
                    card.TurnCard();
            }
        }
    }
}
