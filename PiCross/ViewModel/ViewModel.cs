using Cells;
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
    public class ViewModelMainWindow
    {
        public ViewModelMainWindow()
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

            this.ClickCommand = new ClickRectangle(this);
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

        public IPlayablePuzzle PlayablePuzzle { get; }

        public ICommand ClickCommand { get; private set; }

        public class ClickRectangle : ICommand
        {
            private ViewModelMainWindow viewModelMainWindow;

            public ClickRectangle(ViewModelMainWindow viewModelMainWindow)
            {
                vm = viewModelMainWindow;
                canExcecute = true;
            }

            private ViewModelMainWindow vm;
            private bool canExcecute;

            public EventHandler CanExecuteChange;

            public event EventHandler CanExecuteChanged;


            private void ChangeValue(IPlayablePuzzleSquare square)
            {
                if (vm.PlayablePuzzle.Grid[square.Position].Contents.Value == Square.EMPTY || vm.PlayablePuzzle.Grid[square.Position].Contents.Value == Square.UNKNOWN)
                {
                    vm.PlayablePuzzle.Grid[square.Position].Contents.Value = Square.FILLED;
                }
                else
                {
                    vm.PlayablePuzzle.Grid[square.Position].Contents.Value = Square.EMPTY;
                }
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