using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.ViewModel
{
    using Model;
    class RosterViewModel
    {
        private Roster _roster; 

        public RosterViewModel(Roster roster)
        {
            _roster = roster;

            TeamName = _roster.TeamName;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();
            
            UpdateRosters();
        }

        public string TeamName { get; private set; }

        public ObservableCollection<PlayerViewModel> Starters { get; private set; }
        public ObservableCollection<PlayerViewModel> Bench { get; private set; }

        private void UpdateRosters()
        {
            var starterPlayers = from player in _roster.Players where player.Starter select player;
            var benchPlayer = from player in _roster.Players where player.Starter == false select player;

            foreach(Player player in starterPlayers)
            {
                Starters.Add(new PlayerViewModel(player.Name, player.Number));
            }

            foreach(Player player in benchPlayer)
            {
                Bench.Add(new PlayerViewModel(player.Name, player.Number));
            }
        }

    }
}
