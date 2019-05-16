using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            this.ActiveWindow = new StartScreenViewModel(this);
            this.PiCrossFacade = new PiCrossFacade();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private object activeWindow;

        public PiCrossFacade PiCrossFacade { get; }

        public Action ClosingAction { get; set; }

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }
            private set
            {
                activeWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveWindow)));
            }
        }

        public void StartGame()
        {
            this.ActiveWindow = new GameViewModel(this);
        }

        public void StartGame(IPlayablePuzzle puzzle)
        {
            this.ActiveWindow = new GameViewModel(this, puzzle);
        }

        public void ChooseGame()
        {
            this.ActiveWindow = new ChooseWindowViewModel(this);
        }

        public void StartView()
        {
            this.ActiveWindow = new StartScreenViewModel(this);
        }

        public void CloseWindow()
        {
            this.ClosingAction?.Invoke();
        }


    }
}
