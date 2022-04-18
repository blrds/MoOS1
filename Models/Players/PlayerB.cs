namespace MoOS1.Models.Players
{
    /// <summary>
    /// Игрок Б
    /// </summary>
    class PlayerB
    {

        private bool[] yes = new bool[] {true,true,true,true,true,
                                        true,true,true,true,true,
                                        true,true,true,true,true,
                                        true,true,true,true,true,
                                        true,true,true,true,true};


        private bool[] no = new bool[] {false,false,false,false,false,
                                        false,false,false,false,false,
                                        false,false,false,false,false,
                                        false,false,false,false,false,
                                        false,false,false,false,false};


        private bool[] algorithm = new bool[] {true,true,true,true,true, false,false,false,false,false,false,
                                             true,true, false,false,false,false,
                                             true,true,true,true, false,
                                             true, false,false};
        /// <summary>
        /// Набор инструкций на все ходы
        /// </summary>
        private bool[] answers;
        
        /// <summary>
        /// Конструктор для определения алгоритма поведения
        /// </summary>
        /// <param name="i">0-всегда да, 1-всегда нет, остальное-алгоритм</param>
        public PlayerB(int i)
        {
            switch (i) {
                case 0: { answers = yes; break; }
                case 1: { answers = no; break; }
                case 2: { answers = algorithm; break; }
                default: { answers = algorithm; break; }
            }
        }

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
