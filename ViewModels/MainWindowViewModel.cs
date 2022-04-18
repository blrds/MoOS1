using MoOS1.Infrastructure.Commands;
using MoOS1.Models;
using MoOS1.Models.Players;
using MoOS1.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MoOS1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public Game Game { get; } = new Game();

        private int _simulationsCount;

        /// <summary>
        /// Кол-во симуляций
        /// </summary>
        public int SimulationsCount
        {
            get { return _simulationsCount; }
            set { _simulationsCount = value; }
        }

        /// <summary>
        /// Индекс выбранного режима в комбобоксе
        /// </summary>
        public int SelectedPlayerAMode { get; set; }
        
        /// <summary>
        /// Индекс выбранного режима в комбобоксе
        /// </summary>
        public int SelectedPlayerBMode { get; set; }

        /// <summary>
        /// Коллекция игр, переменная Game является последней
        /// </summary>
        public ObservableCollection<Game> Games { get; } = new ObservableCollection<Game>();

        /// <summary>
        /// Статистика побед А к победам Б
        /// </summary>
        public string Statistic
        {
            get
            {
                string answer = "";
                answer += "" + Games.Where(x => x.Winner == "A").Count();
                answer += ":";
                answer += "" + Games.Where(x => x.Winner == "B").Count();
                return answer;
            }
        }

        #region StartCommand

        /// <summary>
        /// Команда старт для кнопки старт
        /// </summary>
        public ICommand StartCommand { get; private set; }
        private bool CanStartCommnadExecute(object p) => true/*(Game.movesCount>0 && Game.fieldSize>2 && !Game.isGameOn && SimulationsCount>0)*/;
        private void OnStartCommandExecuted(object p)
        {
            Games.Clear();
            switch (SelectedPlayerAMode)
            {
                case 0: { Game.playerA = new WinnerA(); break; }
                case 1: { Game.playerA = new RandomA(); break; }
                default: { Game.playerA = new RandomA(); break; }
            }
            Game.playerB = new PlayerB(SelectedPlayerBMode);
            for (int i = 0; i < SimulationsCount - 1/*-1 тк под одну игру есть отдельная переменная*/; i++)
            {
                var game = new Game();
                game.playerA = Game.playerA;
                game.Start();
                Games.Add(game);
            }
            Game.Start();
            Games.Add(Game);
            OnPropertyChanged("Statistic");
        }
        #endregion

        public MainWindowViewModel()
        {
            StartCommand = new LambdaCommand(OnStartCommandExecuted, CanStartCommnadExecute);
        }
    }
}
