using System;

namespace BlackJackGame.Models
{
    public class BlackJackCard : Card
    {
        public Boolean FaceUp { get; private set; }
        public int Value
        {
            get
            {
                if (!FaceUp) return 0;
                return Math.Min(10, (int)FaceValue);
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
