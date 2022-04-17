using MoOS1.Infrastructure.Commands;
using MoOS1.Models;
using MoOS1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoOS1.ViewModels
{
    class MainWindowViewModel:ViewModel
    {
        public Game Game { get; } = new Game();

        #region StartCommand
        public ICommand StartCommand { get; }
        private bool CanStartCommnadExecute(object p) => (Game.movesCount>0 && Game.fieldSize>2 && !Game.isGameOn);
        private void OnStartCommandExecuted(object p)
        {
            Game.isGameOn = !Game.isGameOn;
        }
        #endregion

        public MainWindowViewModel() {
            StartCommand = new LambdaCommand(OnStartCommandExecuted, CanStartCommnadExecute);
        }
    }
}
