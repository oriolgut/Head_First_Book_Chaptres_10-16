using System;

namespace StarryNightWindowsApp.Model
{
    class BeeMovedEventArgs : EventArgs
    {
        public BeeMovedEventArgs(Bee beeThatMoved, double x, double y)
        {
            BeeThatMoved = beeThatMoved;
            X = x;
            Y = y;
        }

        public Bee BeeThatMoved { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
    }
}
