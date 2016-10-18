using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;

namespace StarryNightWindowsApp.Model
{
    class BeeStarModel
    {
        public static readonly Size _starSize = new Size(150, 100);

        private readonly Dictionary<Bee, Point> _bees = new Dictionary<Bee, Point>();
        private readonly Dictionary<Star, Point> _stars = new Dictionary<Star, Point>();

        private Random _random = new Random();
        private Size _playAreaSize;

        public BeeStarModel()
        {
            _playAreaSize = Size.Empty;
        }

        public event EventHandler<BeeMovedEventArgs> BeeMoved;
        public event EventHandler<StarChangedEventArgs> StarChanged;
        public Size PlayAreaSize
        {
            get
            {
                return _playAreaSize;
            }

            set
            {
                _playAreaSize = value;
                CreateBees();
                CreateStars();
            }
        }

        public void Update()
        {
            MoveOnBee();
            AddOrRemoveAStar();
        }

        private static bool isRectOverlapping(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if (r1.Width > 0 || r1.Height > 0)
            {
                return true;
            }
            return false;
        }

        private void CreateBees()
        {
            if (PlayAreaSize == Size.Empty)
            {
                return;
            }
            if (_bees.Count < 1)
            {
                int beeCount = _random.Next(5, 16);
                for (int i = 0; i < beeCount; i++)
                {
                    int s = _random.Next(40, 151);
                    Size beeSize = new Size(s, s);
                    Point newLocation = FindNonOverlappingPoint(beeSize);
                    Bee newBee = new Bee(newLocation, beeSize);
                    _bees[newBee] = new Point(newLocation.X, newLocation.Y);
                    OnBeeMoved(newBee, newLocation.X, newLocation.Y);
                }
            }
            else
            {
                List<Bee> bees = _bees.Keys.ToList();
                foreach (Bee bee in bees)
                {
                    MoveOnBee(bee);
                }
            }
        }

        private void CreateStars()
        {
            if (PlayAreaSize == Size.Empty)
            {
                return;
            }
            if (_stars.Count == 0)
            {
                int starCount = _random.Next(5, 16);
                for (int i = 0; i < starCount; i++)
                {
                    CreateAStar();
                }
            }
            else
            {
                foreach (Star star in _stars.Keys)
                {
                    Point newPoint = FindNonOverlappingPoint(_starSize);
                    star.Location = newPoint;
                    OnStarChanged(star, false);
                }
            }
        }

        private void CreateAStar()
        {
            Point newPoint = FindNonOverlappingPoint(_starSize);
            Star newStar = new Star(newPoint);
            _stars[newStar] = new Point(newPoint.X, newPoint.Y);
            OnStarChanged(newStar, false);
        }

        private Point FindNonOverlappingPoint(Size size)
        {
            Rect newRect;
            bool isOverlapping = false;
            int count = 0;

            while (!isOverlapping)
            {
                newRect = new Rect(_random.Next((int)PlayAreaSize.Width - 200), _random.Next((int)PlayAreaSize.Height - 200), size.Width, size.Height);

                var overlappingBees =
                    from bee in _bees.Keys
                    where isRectOverlapping(bee.Position, newRect)
                    select bee;

                var overlappingStars =
                    from star in _stars.Keys
                    where isRectOverlapping(new Rect(star.Location.X, star.Location.Y, _starSize.Width, _starSize.Height), newRect)
                    select star;

                if ((overlappingBees.Count() + overlappingStars.Count() == 0) || (count++ > 1000))
                {
                    isOverlapping = true;
                }
            }
            return new Point(newRect.X, newRect.Y);
        }

        private void MoveOnBee(Bee bee = null)
        {
            if (_bees.Count == 0)
            {
                return;
            }
            if (bee == null)
            {
                List<Bee> bees = _bees.Keys.ToList();
                bee = bees[_random.Next(bees.Count)];
            }
            Point newPoint = FindNonOverlappingPoint(bee.Size);
            bee.Location = newPoint;
            _bees[bee] = newPoint;
            OnBeeMoved(bee, newPoint.X, newPoint.Y);
        }

        private void AddOrRemoveAStar()
        {
            if (_random.Next(2) == 0)
            {
                if (NeedToCreateOrDeleteAStar() == 0)
                {
                    CreateAStar();
                }
            }
            else
            {
                if (NeedToCreateOrDeleteAStar() == 0)
                {
                    RemoveAStar();
                }
            }
        }

        private int NeedToCreateOrDeleteAStar()
        {
            List<Star> stars = _stars.Keys.ToList();
            if (stars.Count <= 5)
            {
                CreateAStar();
                return 1;
            }

            if (stars.Count >= 20)
            {
                RemoveAStar();
                return -1;
            }
            return 0;
        }

        private void RemoveAStar()
        {
            List<Star> stars = _stars.Keys.ToList();
            Star starToRemove = stars[_random.Next(stars.Count)];
            _stars.Remove(starToRemove);
            OnStarChanged(starToRemove, true);
        }

        private void OnBeeMoved(Bee beeThatMoved, double x, double y)
        {
            BeeMoved?.Invoke(this, new BeeMovedEventArgs(beeThatMoved, x, y));
        }

        private void OnStarChanged(Star starThatChanged, bool removed)
        {
            StarChanged?.Invoke(this, new StarChangedEventArgs(starThatChanged, removed));
        }
    }
}
