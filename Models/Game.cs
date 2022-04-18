using MoOS1.Infrastructure.ObservableObjects;
using MoOS1.Models.GameBase;
using MoOS1.Models.Players;
using MoOS1.Models.Players.PlayerABase;
using System.Collections.ObjectModel;

namespace MoOS1.Models
{
    class Game : ObservableObject
    {
        #region Observables

        private bool _isGameOn = false;
        /// <summary>
        /// Показывает проходит ли игра прямо сейчас
        /// </summary>
        public bool isGameOn { get { return _isGameOn; } private set { _isGameOn = value; NotifyPropertyChanged(); } }

        private int _fieldSize = 5;
        /// <summary>
        /// Размер игрового поля
        /// </summary>
        public int fieldSize { get { return _fieldSize; } set { _fieldSize = value; NotifyPropertyChanged(); } }

        private int _movesCount = 25;
        /// <summary>
        /// Кол-во ходов на игру
        /// </summary>
        public int movesCount { get { return _movesCount; } set { _movesCount = value; NotifyPropertyChanged(); } }
        public ObservableCollection<MoveInformation> Moves { get; } = new ObservableCollection<MoveInformation>();

        private string _Winner = "";
        /// <summary>
        /// Победитель
        /// </summary>

        public string Winner { get { return _Winner; } private set { _Winner = value; NotifyPropertyChanged(); } }


        public Game()
        {
        }
        #endregion

        /// <summary>
        /// Игрок А; не задан явно, тк имеет несколько типов
        /// </summary>
        public PlayerA playerA { get; set; }

        /// <summary>
        /// Игрок Б
        /// </summary>
        public PlayerB playerB { get; set; }

        /// <summary>
        /// Строка состояний игры во времени
        /// </summary>
        /// <returns>
        /// Строку, в которой через запятую перечислена основная информация о каждом ходе
        /// </returns>
        public string MovesSummarize
        {
            get
            {
                string answer = "";
                foreach (var a in Moves)
                {
                    if (a.PlayerBAnswer) answer += "+";
                    else answer += "-";
                    answer += ": " + a.FinalMove + ", ";
                }
                answer=answer.Remove(answer.Length - 2, 1);
                return answer;
            }
        }
        /// <summary>
        /// Основной цикл игры
        /// </summary>
        public void Start()
        {
            if (playerA == null) return;//если игрок А по каким-либо причинам не задан
            if (playerB == null) return;//если игрок B по каким-либо причинам не задан
            _isGameOn = true;

            #region preparations
            if(Moves.Count>0)Moves.Clear();//чистка после предыдущей игры, если таковая была
            #endregion

            int currentPosition = 0;
            string winnerFlag = "A";
            for (int i = 0; i < _movesCount; i++)
            {
                int playerACall = playerA.Call(currentPosition);//вопрос от А
                bool playerBAnswer = playerB.Answer(i, currentPosition, playerACall, out int finalPosition);//ответ от В
                Moves.Add(new MoveInformation(i,currentPosition, playerACall, playerBAnswer, finalPosition));//сохранение кода
                
                if (finalPosition >= fieldSize - 1)//проверка на победу
                {
                    winnerFlag = "B";
                    break;
                }
                currentPosition = finalPosition;
            }

            Winner = winnerFlag;//сохранение победителя
            _isGameOn = false;
        }

    }
}
