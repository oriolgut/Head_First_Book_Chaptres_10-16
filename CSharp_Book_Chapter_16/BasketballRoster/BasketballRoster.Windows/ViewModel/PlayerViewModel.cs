﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.ViewModel
{
    class PlayerViewModel
    {
        public PlayerViewModel(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public string Name { get; private set; }
        public int Number { get; private set; }
    }
}
