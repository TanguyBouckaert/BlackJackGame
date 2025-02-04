﻿using System;
namespace BlackJackGame.Models
{
    public class BlackJack
    {
        #region Fields
        public const bool FaceDown = false;
        public const bool FaceUp = true;
        private readonly Deck _deck;
        #endregion

        #region Properties 
        //Setters moeten private zijn!!!!
        public GameState GameState { get; private set; }
        public Hand PlayerHand { get; private set; }
        public Hand DealerHand { get; private set; }
        #endregion


        #region Constructors
        public BlackJack() : this(new Deck()) { }

        public BlackJack(Deck deck)
        {//vergeten methode deal toe te voegen!!!!
            _deck = deck;
            PlayerHand = new Hand();
            DealerHand = new Hand();
            Deal();
        }
        #endregion

        #region Methodes

        public void AddCardToHand(Hand hand, bool faceUp)
        {//methode niet ingevuld!!!!!
            BlackJackCard card = _deck.Draw();
            if (faceUp)
                card.TurnCard();
            hand.AddCard(card);
        }

        private void AdjustGameState(GameState? gameState = null)
        {// deel van gamesummary moet eigenlijk hier staan
            /*
            if (this.gameSate == gameState.PlayerPlays)
            {
                int totaal = PlayerHand.CalculateValue();
                //totaal >= 21 ? this.gameSate = new gameState(): this.gameSate;
            }
            */

            if (gameState.HasValue)
                GameState = gameState.Value;
            if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
                PassToDealer();
            if (GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || DealerHand.Value >= 21 || DealerHand.Value >= PlayerHand.Value))
                GameState = GameState.GameOver;
        }
        public void Deal()
        {
            /*
            PlayerHand.AddCard(_deck.Draw());
            PlayerHand.AddCard(_deck.Draw());
            PlayerHand.TurnAllCardsFaceUp();

            !!!!! Verkeerde methode gebruikt om kaart toe te voegen !!!!!

            PlayerHand.CalculateValue().Equals(21) ? Console.WriteLine($"{GameSummary()}") : AdjustGameState(gameState.PlayerPlays);
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            DealerHand.AddCard(_deck.Draw()); //niet zeker of face up of down
            */

            AddCardToHand(DealerHand, FaceUp);
            AddCardToHand(DealerHand, FaceDown);
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState(GameState.PlayerPlays);
        }

        public string GameSummary()
        {//deel zit al in methode adjustgamestate, kon ook opgelost worden met enkel if's
            /*
            if (this.gameSate == gameState.GameOver){
            switch (PlayerHand.CalculateValue().Equals(21) || DealerHand.CalculateValue().Equals(21))
            {case true:return "BlackJack";
            case false: if (PlayerHand.CalculateValue() > 21)
            {return "Player Burned, Dealer Wins";
            }else if (DealerHand.CalculateValue() > 21)
            {return "Dealer Burned, Player Wins";
            }else if (PlayerHand.CalculateValue() > DealerHand.CalculateValue())
            {return "Player Wins";
            }else
            {return "Dealer Wins";}}}
            else{return null;}
            */

            if (GameState != GameState.GameOver)
                return null;
            if (PlayerHand.Value > 21)
                return "Player burned, dealer wins";
            if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
                return "BLACKJACK";
            if (PlayerHand.Value == DealerHand.Value)
                return "Equal, dealer wins";
            if (DealerHand.Value > 21)
                return "Dealer burned, player wins";
            if (DealerHand.Value > PlayerHand.Value)
                return "Dealer wins";
            return "Player wins";
        }

        public void GivePlayerAnotherCard()
        {//weer slechte methode gebruikt !!!!!
            /*
            if (this.gameSate == gameState.PlayerPlays)
            {
                PlayerHand.AddCard(_deck.Draw());
            }*/

            if (GameState != GameState.PlayerPlays)
                throw new InvalidOperationException("You cannot take a card now...");
            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState();
        }

        public void LetDealerFinalize()
        {//while luske vergeten en methode addcardtohand !!!!!!
            while(GameState == GameState.DealerPlays)
            {
                AddCardToHand(DealerHand, FaceUp);
                AdjustGameState();
            }
        }

        public void PassToDealer()
        {//methode letdealerfinalize vergeten!!!!!!
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState(GameState.DealerPlays);
            LetDealerFinalize();
        }
        #endregion
    }
}
