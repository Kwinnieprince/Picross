using Cells;
using DataStructures;
using PiCross;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ViewModel
{
    public class PlayablePuzzleSquareViewModel
    {
        public IPlayablePuzzleSquare PuzzleSquare { get; }
        public ICommand Cycle { get; }
        public Cell<Square> Contents
        {
            get
            {
                return PuzzleSquare.Contents;
            }
        }

        public PlayablePuzzleSquareViewModel(IPlayablePuzzleSquare puzzleSquare)
        {
            this.PuzzleSquare = puzzleSquare;
        }
    }

    public class CycleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private PlayablePuzzleSquareViewModel vm;
        private bool canExcecute;

        public CycleCommand(PlayablePuzzleSquareViewModel playablePuzzleSquareViewModel)
        {
            vm = playablePuzzleSquareViewModel;
            canExcecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExcecute;
        }

        public void Execute(object parameter)
        {
            var square = parameter as IPlayablePuzzleSquare;

            if (square.Contents.Value == Square.EMPTY || square.Contents.Value == Square.UNKNOWN)
            {
                square.Contents.Value = Square.FILLED;
            }
            else
            {
                square.Contents.Value = Square.EMPTY;
            }
        }
    }
}