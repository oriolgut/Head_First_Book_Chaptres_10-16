using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallSimulator
{
    class Pitcher
    {
        private int _pitcherNumber = 0;
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += Ball_BallInPlay;
        }
        public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            _pitcherNumber++;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                {
                    CatchBall();
                }
                else
                {
                    CoverFirstBase();
                }
            }
        }

        private void CoverFirstBase()
        {
            PitcherSays.Add($"Pitcher #{_pitcherNumber}: I covered the first base.");
        }

        private void CatchBall()
        {
            PitcherSays.Add($"Pitcher #{_pitcherNumber}: I catched the ball.");
        }
    }
}
