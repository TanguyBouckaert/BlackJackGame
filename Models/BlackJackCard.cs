using System;

namespace BlackJackGame.Models
{
    public class BlackJackCard : Card
    {
        public bool FaceUp { get; private set; }//Tanguy: Boolean
        public int Value
        {
            get
            {
                return FaceUp ? Math.Min(10, (int)FaceValue) : 0;
                /*
                if (FaceUp)
                    return Math.Min(10, (int)FaceValue);
                else
                    return 0;
                    */
            }
        }
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue)
        {
            FaceUp = false;

        }

        public void TurnCard()
        {
            FaceUp = !FaceUp;
        }
    }
}
