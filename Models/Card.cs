namespace BlackJackGame.Models
{
    public class Card
    {
        public FaceValue _faceValue { get; }
        public Suit _suit { get; }

        public Card(Suit suit, FaceValue faceValue)
        {
            _faceValue = faceValue;
            _suit = suit;
        }
    }
}
