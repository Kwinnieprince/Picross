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

            this.BackCommand = new BackCommand(mainWindowViewModel);
            this.QuitCommand = new QuitCommand(mainWindowViewModel);
        }

        public ICommand BackCommand { get; }
        public ICommand QuitCommand { get; }

        public GameViewModel(MainWindowViewModel mainWindowViewModel, IPlayablePuzzle playablePuzzle)
        {
            this.Start(mainWindowViewModel, playablePuzzle);
            this.BackCommand = new BackCommand(mainWindowViewModel);
            this.QuitCommand = new QuitCommand(mainWindowViewModel);
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
    }
}