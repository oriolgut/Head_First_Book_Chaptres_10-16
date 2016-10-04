using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BaseBallSimulator
{
    class BaseballSimulator
    {
        private Ball _ball = new Ball();
        private Pitcher _pitcher;
        private Fan _fan;

        public BaseballSimulator()
        {
            _pitcher = new Pitcher(_ball);
            _fan = new Fan(_ball);
        }

        public ObservableCollection<string> FanSays { get { return _fan.FanSays; } }
        public ObservableCollection<string> PitcherSays { get { return _pitcher.PitcherSays; } }

        public int Trajectory { get; set; }
        public int Distance { get; set; }

        public void PlayBall()
        {
            Bat bat = _ball.GetNewBat();
            BallEventArgs ballEventArgs = new BallEventArgs(Trajectory, Distance);
            bat.HitTheBall(ballEventArgs);
        }
    }
}
