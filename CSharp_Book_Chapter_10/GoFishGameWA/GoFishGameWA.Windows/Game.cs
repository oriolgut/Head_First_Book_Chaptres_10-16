using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace GoFishGameWA
{
    class Game
    {
        private List<Player> _players;
        private Deck _stock;
        private Dictionary<Values, Player> _books;
        private event PropertyChangedEventHandler PropertyChanged;

        public Game()
        {
            PlayerName = "Ed";
            Hand = new ObservableCollection<string>();
            ResetGame();
        }

        public bool GameInProgress { get; private set; }
        public bool GameNotStarted { get { return !GameInProgress; } }
        public string PlayerName { get; set; }
        public ObservableCollection<string> Hand { get; private set; }
        public string Books { get { return DescribeBooks(); } }
        public string GameProgress { get; private set; }

        public void AddProgress(string progress)
        {
            GameProgress = $"{progress}{Environment.NewLine}{GameProgress}";
            OnPropertyChanged("GameProgress");
        }

        public void PlayOneRound(int selectedPlayerCard)
        {
            Values selectedValue = _players[0].Peek(selectedPlayerCard).Value;
            for (int i = 0; i < _players.Count; i++)
            {
                if (i == 0)
                    _players[i].AskForACard(_players, 0, _stock, selectedValue);
                else
                    _players[i].AskForACard(_players, i, _stock);

                if (PullOutBooks(_players[i]))
                {
                    DrewNewHand(_players[i]);
                }

                _players[0].SortHand();

                if (_stock.Count == 0)
                {
                    AddProgress($"The stock is out of cards. Game Over!{Environment.NewLine}");
                    AddProgress($"The winner is... {GetWinnerName()}");
                    ResetGame();
                    return;
                }
            }
            Hand.Clear();
            foreach (string cardName in GetPlayerCardNames())
            {
                Hand.Add(cardName);
            }
            if (!GameInProgress)
            {
                AddProgress(DescribePlayerHands());
            }
        }
        
        public void StartGame()
        {
            ClearProgress();
            GameInProgress = true;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            Random random = new Random();
            _players = new List<Player>();
            _players.Add(new Player(PlayerName, random, this));
            _players.Add(new Player("Joe", random, this));
            _players.Add(new Player("Bob", random, this));
            Deal();
            _players[0].SortHand();
            Hand.Clear();
            foreach(string cardName in GetPlayerCardNames())
            {
                Hand.Add(cardName);
            }
            if (!GameInProgress)
            {
                AddProgress(DescribePlayerHands());
            }
            OnPropertyChanged("Books");
            OnPropertyChanged("GameProgress");
        }

        private void ClearProgress()
        {
            GameProgress = string.Empty;
            OnPropertyChanged("GameProgress");
        }

        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> booksPulled = player.PullOutBooks();
            foreach (Values value in booksPulled)
                _books.Add(value, player);
            if (player.CardCount == 0)
                return true;
            return false;
        }

        public string DescribeBooks()
        {
            string bookDescription = "";
            foreach (Values value in _books.Keys)
                bookDescription += _books[value].Name + " has a book of " + Card.Plural(value) + Environment.NewLine;
            return bookDescription;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (Values value in _books.Keys)
            {
                string name = _books[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }
            int mostBooks = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
            bool tie = false;
            string winnerList = "";
            foreach (string name in winners.Keys)
                if (winners[name] == mostBooks)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += " with " + mostBooks + " books";
            if (tie)
                return "A tie between " + winnerList;
            else
                return winnerList;
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return _players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < _players.Count; i++)
            {
                description += _players[i].Name + " has " + _players[i].CardCount;
                if (_players[i].CardCount == 1)
                    description += " card. " + Environment.NewLine;
                else
                    description += " cards. " + Environment.NewLine;
            }

            description += "The stock has " + _stock.Count + " cards left." + Environment.NewLine;
            return description;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ResetGame()
        {
            GameInProgress = false;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            _books = new Dictionary<Values, Player>();
            _stock = new Deck();
            Hand.Clear();
        }
        private void Deal()
        {
            _stock.Shuffle();

            for (int i = 0; i < 5; i++)
                foreach (Player player in _players)
                    player.TakeCard(_stock.Deal());

            foreach(Player player in _players)
                PullOutBooks(player);
        }

        private void DrewNewHand(Player player)
        {
            AddProgress($"{player.Name} drew a new hand {Environment.NewLine}");
            for (int i = 1; i <= 5 && _stock.Count > 0; i++)
            {
                player.TakeCard(_stock.Deal());
            }
        } 
    }
}
