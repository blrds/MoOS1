using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
