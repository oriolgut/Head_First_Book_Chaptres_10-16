using System;

namespace StarryNightWindowsApp.Model
{
    class StarChangedEventArgs : EventArgs
    {
        public StarChangedEventArgs(Star starThatChanged, bool removed)
        {
            StarThatChanged = starThatChanged;
            Removed = removed;
        }

        public bool Removed { get; private set; }
        public Star StarThatChanged { get; private set; }
    }
}
