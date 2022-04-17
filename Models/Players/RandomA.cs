using MoOS1.Models.Players.PlayerABase;
using System;

namespace MoOS1.Models.Players
{
    /// <summary>
    /// Игрок А со случайным методом выбора хода
    /// </summary>
    class RandomA : PlayerA
    {
        private Random r = new Random();
        public override int Call(int currentPosition)
        {
            if (currentPosition == 0) return 1;//тк дальше в -1 уйти нельзя, а стоять нельза, остается только одно
            if (r.NextDouble() >= 0.5) return 1;
            else return  -1;
        }
    }
}
