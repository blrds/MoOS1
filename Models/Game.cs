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
        public bool isGameOn { get { return _isGameOn; } set { _isGameOn = value; NotifyPropertyChanged(); } }

        private int _fieldSize = 5;
        public int fieldSize { get { return _fieldSize; } set { _fieldSize = value; NotifyPropertyChanged(); } }

        private int _movesCount = 25;
        public int movesCount { get { return _movesCount; } set { _movesCount = value; NotifyPropertyChanged(); } }
        public ObservableCollection<MoveInformation> Moves { get; } = new ObservableCollection<MoveInformation>();

        #endregion
        private PlayerA playerA { get; set; }
        private PlayerB playerB { get; set; } = new PlayerB();

        

        public void GameOn() {
            _isGameOn = true;
            int currentPosition = 0;

            #region preparations
            Moves.Clear();
            #endregion

            for (int i = 0; i < _movesCount; i++) {
                int playerACall = playerA.Call(currentPosition);
                bool playerBAnswer = playerB.Answer(i, currentPosition, playerACall, fieldSize, out int finalPosition);
                Moves.Add(new MoveInformation(i, playerACall, playerBAnswer, finalPosition));
                if (finalPosition == fieldSize - 1) break;
                currentPosition = finalPosition;
            }


            _isGameOn = false;
        }

    }
}
