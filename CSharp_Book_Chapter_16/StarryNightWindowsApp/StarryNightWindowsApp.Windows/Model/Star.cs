using Windows.Foundation;

namespace StarryNightWindowsApp.Model
{
    class Star
    {
        public Star(Point location)
        {
            Location = location;
        }

        public Point Location { get; set; }
    }
}
