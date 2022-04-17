using MoOS1.Infrastructure.ObservableObjects;
using MoOS1.Models.GameBase;
using MoOS1.Models.Players;
using MoOS1.Models.Players.PlayerABase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoOS1.Models
{
    class Game : ObservableObject
    {
        #region Observables

        private bool _isGameOn = false;
        public bool isGameOn { get { return _isGameOn; } private set { _isGameOn = value; NotifyPropertyChanged(); } }

        private int _fieldSize = 5;
        public int fieldSize { get { return _fieldSize; } set { _fieldSize = value; NotifyPropertyChanged(); } }

        private int _movesCount = 25;
        public int movesCount { get { return _movesCount; } set { _movesCount = value; NotifyPropertyChanged(); } }
        public ObservableCollection<MoveInformation> Moves { get; } = new ObservableCollection<MoveInformation>();

        private string _Winner = "";

        public string Winner { get { return _Winner; } private set { _Winner = value; NotifyPropertyChanged(); } }


        public Game()
        {
        }
        #endregion
        public PlayerA playerA { get; set; }
        public PlayerB playerB { get; set; } = new PlayerB();

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

        public void Start()
        {
            if (playerA == null) return;
            _isGameOn = true;

            #region preparations
            Moves.Clear();
            #endregion

            int currentPosition = 0;
            string winnerFlag = "A";
            for (int i = 0; i < _movesCount; i++)
            {
                int playerACall = playerA.Call(currentPosition);
                bool playerBAnswer = playerB.Answer(i, currentPosition, playerACall, out int finalPosition);
                Moves.Add(new MoveInformation(i,currentPosition, playerACall, playerBAnswer, finalPosition));
                if (finalPosition >= fieldSize - 1)
                {
                    winnerFlag = "B";
                    break;
                }
                currentPosition = finalPosition;
            }

            Winner = winnerFlag;
            _isGameOn = false;
        }

    }
}
