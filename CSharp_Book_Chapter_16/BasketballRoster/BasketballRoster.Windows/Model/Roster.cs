using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.Model
{
    class Roster
    {
        private readonly List<Player> _players = new List<Player>();

        public Roster(string teamName, IEnumerable<Player> players)
        {
            TeamName = teamName;
            _players.AddRange(players);
        }

        public string TeamName { get; private set; }
        public IEnumerable<Player> Players
        {
            get
            {
                return new List<Player>(_players);
            }
        }
    }
}
