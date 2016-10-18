using Windows.Foundation;

namespace StarryNightWindowsApp.Model
{
    class Bee
    {
        public Bee(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public Point Location { get; set; }
        public Size Size { get; set; }
        public Rect Position { get { return new Rect(Location, Size); } }
        public double Width { get { return Position.Width; } }
        public double Height { get { return Position.Height; } }
    }
}
