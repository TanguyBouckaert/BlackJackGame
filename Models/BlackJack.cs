using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        bool FaceDown;
        bool FaceUp;

        public GameState GameState { get; set; }

        public void AddCardToHand(Hand hand, bool faceUp)
        {

        }

        public void AdjustGameState([GameState? gameState = null])
        {

        }

        public BlackJack()
        {

        }

        public BlackJack(Deck deck)
        {

        }

        public void Deal()
        {

        }

        public string GameSummary()
        {

        }
    }
}
