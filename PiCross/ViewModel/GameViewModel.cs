using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Utility;
using Grid = DataStructures.Grid;


namespace ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.Puzzle = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
            );

            this.vm = mainWindowViewModel;

            this.Facade = new PiCrossFacade();

            this.PlayablePuzzle = Facade.CreatePlayablePuzzle(this.Puzzle);

            this.Start(mainWindowViewModel, PlayablePuzzle);

            this.BackCommand = new EasyCommand(() => this.vm.StartView());
            this.QuitCommand = new EasyCommand(() => this.vm.CloseWindow());

            this.StartTimer();
        }

        public ICommand BackCommand { get; }
        public ICommand QuitCommand { get; }
        public ICommand DelegateCommand { get; }
        public MainWindowViewModel MainWindowViewModel { get; }
        public Puzzle Puzzle;
        public MainWindowViewModel vm;
        public GameViewModel(MainWindowViewModel mainWindowViewModel, IPlayablePuzzle playablePuzzle)
        {
            this.MainWindowViewModel = mainWindowViewModel;
            this.Start(mainWindowViewModel, playablePuzzle);
            this.BackCommand = new EasyCommand(() => this.MainWindowViewModel.StartView());
            this.QuitCommand = new EasyCommand(() => this.MainWindowViewModel.CloseWindow());
            this.StartTimer();
        }

        public void Start(MainWindowViewModel mainWindowViewModel, IPlayablePuzzle puzzle)
        {
            this.Vm = mainWindowViewModel;
            this.PlayablePuzzle = puzzle;
            this.Grid = this.PlayablePuzzle.Grid.Map(puzzleSquare => new PlayablePuzzleSquareViewModel(puzzleSquare)).Copy();
        }

        public Cell<bool> IsSolved
        {
            get
            {
                return PlayablePuzzle.IsSolved;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }

            T oldValue = field;

            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PiCrossFacade Facade { get; }

        public IPlayablePuzzle PlayablePuzzle { get; private set; }

        public ICommand ClickCommand { get; private set; }
        public MainWindowViewModel Vm { get; private set; }
        public IGrid<PlayablePuzzleSquareViewModel> Grid { get; private set; }

        private DispatcherTimer timer;
        private double currentTime;
        public event PropertyChangedEventHandler OnPropertyChanged;

        public double CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                OnPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            }
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            CurrentTime = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CurrentTime += 1;
        }
    }
}