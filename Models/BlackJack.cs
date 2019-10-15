using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        bool FaceDown;
        bool FaceUp;

        #region Properties
        public gameState GameState { get; set; }
        public Hand PlayerHand { get; set; }
        public Hand DealerHand { get; set; }
        public Deck _deck { get; set; }
        #endregion

        public void AddCardToHand(Hand hand, bool faceUp)
        {

        }

        private void AdjustGameState(gameState? GameState = null)
        {
            if(this.GameState == gameState.PlayerPlays)
            {
                int totaal = PlayerHand.CalculateValue();
                //totaal >= 21 ? this.GameState = new gameState(): this.GameState;
            }
        }

        public BlackJack()
        {
            _deck = new Deck();
            PlayerHand = new Hand();
            DealerHand = new Hand();
            PlayerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            PlayerHand.AddCard(_deck.Draw()); //niet zeker of face up of down

            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
        }

        public BlackJack(Deck deck)
        {
            _deck = deck;

            PlayerHand = new Hand();
            DealerHand = new Hand();
            PlayerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            PlayerHand.AddCard(_deck.Draw()); //niet zeker of face up of down

            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
        }

        #region Methodes
        public void Deal()
        {

        }

        public string GameSummary()
        {

        }

        public void GivePlayerAnotherCard()
        {

        }

        public void LetDealerFinalize()
        {

        }

        public void PassToDealer()
        {

        }
        #endregion
    }
}
