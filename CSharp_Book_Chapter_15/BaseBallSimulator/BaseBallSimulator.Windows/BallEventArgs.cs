using System;

namespace BaseBallSimulator
{
    public class BallEventArgs : EventArgs
    {

        public BallEventArgs(int trajectory, int distance)
        {
            Trajectory = trajectory;
            Distance = distance;
        }

        public int Trajectory { get; private set; }
        public int Distance { get; private set; }
    }
}