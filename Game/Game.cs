using Cards;
using Players;

namespace Game_
{
    public class Game
    {
        public List<Card> cardDeck;
        public List<Player> players;

        private readonly Random _random;
        private readonly int _cardsAmount = 36;
        public Game(int playersCount = 4)
        {
            _random = new Random();

            players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player());
            }

            cardDeck = CreateCardDeck();
            ShuffleCards(cardDeck);

            dealCardsToPlayers(players, cardDeck);
        }

        public List<Card> CreateCardDeck()
        {
            cardDeck = new List<Card>();
            int suitCount = _cardsAmount / 4;

            for (int i = 0; i < suitCount; i++)
            {
                cardDeck.Add(new Card((CardValue)i, (CardSuit)0));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)1));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)2));
                cardDeck.Add(new Card((CardValue)i, (CardSuit)3));
            }

            return cardDeck;
        }

        public void ShuffleCards(List<Card> cards)
        {
            cards.Sort((a, b) => _random.Next(-2, 2));
        }

        public void dealCardsToPlayers(List<Player> players, List<Card> cards)
        {
            int currentPlayer = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                players[currentPlayer].cards.Add(cards[i]);

                currentPlayer++;
                currentPlayer %= players.Count;
            }
        }

        public bool PlayersTurn()
        {
            Console.WriteLine("Хiд гравцiв:");
            Console.WriteLine("гравець\t\tк-сть карт\tхiд картою");

            int maxValue = -1;
            Player? playerWithMaxValue = null;
            Stack<Card> cardStack = new Stack<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];

                if (player.cards.Count > 0)
                {
                    Card card = player.cards[_random.Next(player.cards.Count)];

                    Console.WriteLine($"{i + 1}\t\t{player.cards.Count}\t\t{card}");
                    player.cards.Remove(card);

                    if ((int)card.value > maxValue)
                    {
                        maxValue = (int)card.value;
                        playerWithMaxValue = player;
                    }

                    cardStack.Push(card);

                }
            }

            playerWithMaxValue!.cards.AddRange(cardStack);
            Console.WriteLine($"Забрав гравець {players.IndexOf(playerWithMaxValue) + 1}.");
            Console.WriteLine("------------------------------------------------");

            if (playerWithMaxValue.cards.Count == _cardsAmount)
            {
                Console.WriteLine($"Перемiг гравець {players.IndexOf(playerWithMaxValue) + 1}");
                return false;
            }

            return true;
        }
    }
}