using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoes
{
    class MenuMaker : INotifyPropertyChanged
    {
        private Random _random = new Random();
        private List<String> _meats = new List<String>() {"Roast beef", "Salami", "Turkey", "Ham", "Pastrami" };
        private List<String> _condiments = new List<string>() { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
        private List<string> _breads = new List<string>() { "rye", "white", "wheat", "pumpernickel", "italian bread", "a roll" };

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuMaker()
        {
            Menu = new ObservableCollection<MenuItem>();
            NumberOfItems = 10;
            UpdateMenu();
        }

        public DateTime GeneratedDate { get; private set; }
        public int NumberOfItems { get; set; }
        public ObservableCollection<MenuItem> Menu { get; private set; }

        public void UpdateMenu()
        {
            Menu.Clear();
            for(int i = 0; i < NumberOfItems; i++)
            {
                Menu.Add(CreateMenuItem());
            }
            GeneratedDate = DateTime.Now;
            OnPropertyChanged("GeneratedDate");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MenuItem CreateMenuItem()
        {
            string randomMeat = _meats[_random.Next(_meats.Count)];
            string randomCondiment = _condiments[_random.Next(_condiments.Count)];
            string randomBread = _breads[_random.Next(_breads.Count)];
            return new MenuItem(randomMeat, randomCondiment, randomBread);
        }
    }
}
