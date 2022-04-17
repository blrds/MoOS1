namespace MoOS1.Models.Players.PlayerABase
{
    /// <summary>
    /// прототип класа Игрока А, нужен для upcast'a
    /// </summary>
    abstract class PlayerA
    {
        public abstract int Call(int currentPosition);
    }
}
