using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StartScreenViewModel
    {
        public StartScreenViewModel()
        {
            this.Start = new StartCommand();
            this.Choose = new ChooseCommand();
            this.Quit = new QuitCommand();
        }

        public ICommand Start { get; }

        public ICommand Choose { get; }

        public ICommand Quit { get; }

        
    }
    public class StartCommand : ICommand
    {

        public event PropertyChangedEventHandler propertyChanged;

        private object activeWindow;

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }

            set
            {
                activeWindow = value;
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(activeWindow)));
            }
        }

        public event EventHandler CanExecuteChanged;
        private bool canExecute;

        public StartCommand()
        {
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            //startScreenViewModel.startGame();
            this.activeWindow = new ViewModelMainWindow();
        }

        public void chooseGame()
        {
            this.activeWindow = new ViewModelMainWindow();
        }

    }
    public class ChooseCommand : ICommand
    {

        public event PropertyChangedEventHandler propertyChanged;

        private object activeWindow;

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }

            set
            {
                activeWindow = value;
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(activeWindow)));
            }
        }

        public event EventHandler CanExecuteChanged;
        private ViewModelMainWindow viewModelMainWindow;
        private bool canExecute;

        public ChooseCommand()
        {
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            this.activeWindow = new ViewModelMainWindow();
        }
    }

    public class QuitCommand : ICommand
    {

        public event PropertyChangedEventHandler propertyChanged;

        private object activeWindow;

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }

            set
            {
                activeWindow = value;
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(activeWindow)));
            }
        }

        public event EventHandler CanExecuteChanged;
        private ViewModelMainWindow viewModelMainWindow;
        private bool canExecute;

        public QuitCommand()
        {
            //viewModelMainWindow = vm;
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            
        }

    }
}
