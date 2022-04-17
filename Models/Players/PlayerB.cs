using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoOS1.Models.Players
{
    /// <summary>
    /// Игрок Б
    /// </summary>
    class PlayerB
    {
        /// <summary>
        /// Набор инструкций на все ходы
        /// </summary>
        private bool[] answers = new bool[] {true,true,true,true,true, false,false,false,false,false,false,
                                             true,true, false,false,false,false,
                                             true,true,true,true, false,
                                             true, false,false};

        /// <summary>
        /// Ответ игрока Б
        /// </summary>
        /// <param name="move"> номер хода </param>
        /// <param name="currentPosition"> текущее размещение </param>
        /// <param name="playerACall"> действие игрока А </param>
        /// <param name="finalMove">итоговый ход</param>
        /// <returns>действие игрока Б, где true-согласен, false-нет</returns>
        public bool Answer(int move, int currentPosition, int playerACall, out int finalMove)
        {
            if (currentPosition == 0) finalMove = 1;//тк из 0 только один путь, то инструкции игнорируются
            else if (answers[move % 25]) finalMove = currentPosition + playerACall;//%25, для ситуций, когда было задано больше 25 ходов
            else finalMove = currentPosition + playerACall * -1;
            return answers[move % 25];

        }
    }
}
