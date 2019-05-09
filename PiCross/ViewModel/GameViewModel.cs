using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            this.Facade = new PiCrossFacade();

            this.PlayablePuzzle = Facade.CreatePlayablePuzzle(this.Puzzle);

            this.Start(mainWindowViewModel, PlayablePuzzle);
        }

        public GameViewModel(MainWindowViewModel mainWindowViewModel, IPlayablePuzzle playablePuzzle)
        {
            this.Start(mainWindowViewModel, PlayablePuzzle);
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

        public Puzzle Puzzle;

        public PiCrossFacade Facade { get; }

        public IPlayablePuzzle PlayablePuzzle { get; private set; }

        public ICommand ClickCommand { get; private set; }
        public MainWindowViewModel Vm { get; private set; }
        public IGrid<PlayablePuzzleSquareViewModel> Grid { get; private set; }

        public class ClickRectangle : ICommand
        {
            private GameViewModel viewModelMainWindow;

            public ClickRectangle(GameViewModel viewModelMainWindow)
            {
                vm = viewModelMainWindow;
                canExcecute = true;
            }

            private GameViewModel vm;
            private bool canExcecute;

            public EventHandler CanExecuteChange;

            public event EventHandler CanExecuteChanged;


            private void ChangeValue(IPlayablePuzzleSquare square)
            {
               
            }

            public bool CanExecute(object parameter)
            {
                return canExcecute;
            }

            public void Execute(object parameter)
            {
                var square = parameter as IPlayablePuzzleSquare;
                ChangeValue(square);
            }
        }
    }
}