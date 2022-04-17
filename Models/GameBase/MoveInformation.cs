namespace MoOS1.Models.GameBase
{
    /// <summary>
    /// Основная информация об одном ходе
    /// </summary>
    class MoveInformation
    {
        /// <summary>
        /// Основная информация об одном ходе
        /// </summary>
        /// <param name="move"> номер хода </param>
        /// <param name="currentLocation"> текущее размещение </param>
        /// <param name="playerACall"> действие игрока А </param>
        /// <param name="playerBAnswer"> действие игрока В </param>
        /// <param name="finalMove"> итоговый ход </param>
        public MoveInformation(int move, int currentLocation, int playerACall, bool playerBAnswer, int finalMove)
        {
            Move = move;
            PlayerACall = playerACall;
            PlayerBAnswer = playerBAnswer;
            FinalMove = finalMove;
            CurrentLocation = currentLocation;
        }
        /// <summary>
        /// Номер хода
        /// </summary>
        public int Move { get; }

        /// <summary>
        /// Действие игрока А
        /// </summary>
        public int PlayerACall { get; }

        /// <summary>
        /// Ответ игрока Б 
        /// </summary>
        public bool PlayerBAnswer { get; }

        /// <summary>
        /// Итоговый ход
        /// </summary>
        public int FinalMove { get; }

        /// <summary>
        /// Размещение до хода
        /// </summary>
        public int CurrentLocation { get; }
    }
}
