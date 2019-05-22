using DataStructures;
using PiCross;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ChooseWindowViewModel
    {
        public ChooseWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.vm = mainWindowViewModel;

            Puzzle puzzle1 = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
            );

            Puzzle puzzle2 = Puzzle.FromRowStrings(
                "xxxxx",
                "x.x.x",
                "x.x.x",
                "x.x.x",
                "xxxxx"
            );

            Puzzle puzzle3 = Puzzle.FromRowStrings(
                "..x..",
                ".x.x.",
                "x...x",
                ".x.x.",
                "..x.."
            );


            var data = this.vm.PiCrossFacade.CreateDummyGameData();

            var list = data.PuzzleLibrary.Entries;

            this.Puzzles = new ArrayList();

            foreach (IPuzzleLibraryEntry entry in list)
            {
                this.Puzzles.Add(this.vm.PiCrossFacade.CreatePlayablePuzzle(entry.Puzzle));
            }

            this.ChoosePuzzleCommand = new ChoosePuzzleCommand(mainWindowViewModel);
            this.BackCommand = new EasyCommand(() => this.vm.StartView());
            this.QuitCommand = new EasyCommand(() => this.vm.CloseWindow()); 
        }

        public PiCrossFacade Facade;

        public MainWindowViewModel vm;

        public ArrayList Puzzles { get; }
        public ICommand ChoosePuzzleCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand QuitCommand { get; }
    }

    public class ChoosePuzzleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel vm { get; }


        public ChoosePuzzleCommand(MainWindowViewModel mainWindowViewModel)
        {
            vm = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var puzzle = parameter as IPlayablePuzzle;
            this.vm.StartGame(puzzle);
        }
    }
}
