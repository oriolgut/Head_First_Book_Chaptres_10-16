using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallSimulator
{
    class Ball
    {
        public event EventHandler BallInPlay;

        protected void OnBallInPlay(BallEventArgs e)
        {
            BallInPlay?.Invoke(this, e);
        }
        public Bat GetNewBat()
        {
            return new Bat(new BatCallback(OnBallInPlay));
        }
    }
}
