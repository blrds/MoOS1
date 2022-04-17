using MoOS1.Models.Players.PlayerABase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoOS1.Models.Players
{
    class RandomA : PlayerA
    {
        private Random r = new Random();
        public override int Call(int currentPosition)
        {
            if (currentPosition == 0) return 1;
            if (r.NextDouble() >= 0.5) return 1;
            else return  -1;
        }
    }
}
