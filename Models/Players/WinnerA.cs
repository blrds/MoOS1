using MoOS1.Models.Players.PlayerABase;

namespace MoOS1.Models.Players
{
    /// <summary>
    /// Игрок А стремящийся всегда увести противника ближе к началу
    /// </summary>
    class WinnerA : PlayerA
    {
        public override int Call(int currentPosition)
        {
            if (currentPosition == 0) return 1;//тк дальше в -1 уйти нельзя, а стоять нельза, остается только одно
            else return -1;
        }
    }
}
