namespace Cards
{ 
    public enum CardValue { ШIСТЬ = 0, СIМ, ВIСIМ, ДЕВЯТЬ, ДЕСЯТЬ, ВАЛЕТ, КОРОЛЕВА, КОРОЛЬ, ТУЗ }
    public enum CardSuit{ ЧИРВА = 0, БУБА, ТРЕФА, ПIКА }

    public class Card
    {

        public readonly CardValue value;
        public readonly CardSuit suit;

        public Card(CardValue value, CardSuit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"{value} {suit}";
        }
    }
}