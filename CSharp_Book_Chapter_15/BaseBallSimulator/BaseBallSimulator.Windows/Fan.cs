using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BaseBallSimulator
{
    class Fan
    {
        private int _pitcherNumber = 0;
        public Fan(Ball ball)
        {
            ball.BallInPlay += Ball_BallInPlay;
        }

        public ObservableCollection<string> FanSays = new ObservableCollection<string>();

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            _pitcherNumber++;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Trajectory > 30))
                {
                    FanSays.Add($"Pitcher #{_pitcherNumber}: Home Run! I'm going for the ball.");
                }
                else
                {
                    FanSays.Add($"Pitcher #{_pitcherNumber}: Woo-hoo! Yeah!");
                }
            }
        }

    }
}
