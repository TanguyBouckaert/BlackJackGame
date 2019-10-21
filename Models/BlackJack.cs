using System;
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
            if (this.GameState == gameState.PlayerPlays)
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
            
        }

        public BlackJack(Deck deck)
        {
            _deck = deck;

            PlayerHand = new Hand();
            DealerHand = new Hand();
            
        }

        #region Methodes
        public void Deal()
        {
            PlayerHand.AddCard(_deck.Draw()); 
            PlayerHand.AddCard(_deck.Draw());
            PlayerHand.TurnAllCardsFaceUp();

            PlayerHand.CalculateValue().Equals(21) ? Console.WriteLine($"{GameSummary()}"):AdjustGameState(gameState.PlayerPlays);
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
        }

        public string GameSummary()
        {
            if (this.GameState == gameState.GameOver)
            {
                switch (PlayerHand.CalculateValue().Equals(21) || DealerHand.CalculateValue().Equals(21))
                {
                    case true:
                        return "BlackJack";

                    case false:

                        if (PlayerHand.CalculateValue() > 21)
                        {
                            return "Player Burned, Dealer Wins";

                        }
                        else if (DealerHand.CalculateValue() > 21)
                        {
                            return "Dealer Burned, Player Wins";

                        }
                        else if (PlayerHand.CalculateValue() > DealerHand.CalculateValue())
                        {
                            return "Player Wins";

                        }
                        else
                        {
                            return "Dealer Wins";
                        }
                }
            }
            else
            {
                return null;
            }
        }

        public void GivePlayerAnotherCard()
        {
            if (this.GameState == gameState.PlayerPlays)
            {
                PlayerHand.AddCard(_deck.Draw());
            }
        }

        public void LetDealerFinalize()
        {
            AdjustGameState(gameState.DealerPlays);
        }

        public void PassToDealer()
        {
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState(gameState.DealerPlays);
        }
        #endregion
    }
}
