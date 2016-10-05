using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.Model
{
    class Player
    {
        public Player(string name, int number, bool isStarter)
        {
            Name = name;
            Number = number;
            Starter = isStarter;
        }

        public string Name { get; private set; }
        public int Number { get; private set; }
        public bool Starter { get; private set; }
    }
}
