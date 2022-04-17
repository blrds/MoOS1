using MoOS1.Infrastructure.ObservableObjects;
using MoOS1.Models.GameBase;
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
        private bool _isGameOn = false;
        public bool isGameOn { get { return _isGameOn; } set { _isGameOn = value; NotifyPropertyChanged(); } }

        private int _fieldSize = 5;
        public int fieldSize { get { return _fieldSize; } set { _fieldSize = value; NotifyPropertyChanged(); } }

        private int _movesCount = 25;
        public int movesCount { get { return _movesCount; } set { _movesCount = value; NotifyPropertyChanged(); } }
        public ObservableCollection<MoveInformation> Moves { get; } = new ObservableCollection<MoveInformation>();

        public Game()
        {
            isGameOn = false;
            fieldSize = 5;
            movesCount = 25;
        }

    }
}
