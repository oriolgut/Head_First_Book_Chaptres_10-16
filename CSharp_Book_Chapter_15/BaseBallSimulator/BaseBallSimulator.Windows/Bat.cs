using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallSimulator
{
    class Bat
    {
        private BatCallback hitBallCallback;
        public Bat(BatCallback callbackDelegate)
        {
            hitBallCallback = new BatCallback(callbackDelegate);
        }

        public void HitTheBall(BallEventArgs e)
        {
            hitBallCallback?.Invoke(e);
        }
    }
}
