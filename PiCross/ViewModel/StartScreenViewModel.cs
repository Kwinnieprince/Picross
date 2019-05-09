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
        public StartScreenViewModel(MainWindowViewModel mainWindowView)
        {
            this.vm = mainWindowView;
            this.Start = new StartCommand(this.vm);
            this.Choose = new ChooseCommand(this.vm);
            this.Quit = new QuitCommand(this.vm);
        }

        private MainWindowViewModel vm { get; }

        public ICommand Start { get; }

        public ICommand Choose { get; }

        public ICommand Quit { get; }

        public event PropertyChangedEventHandler propertyChanged;
    }
    public class StartCommand : ICommand
    {
        public object activewindow;

        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel mainWindowViewModel;
        private bool canExecute;

        public StartCommand(MainWindowViewModel vm)
        {
            mainWindowViewModel = vm;
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            mainWindowViewModel.StartGame();
        }


    }
    public class ChooseCommand : ICommand
    {

        public event PropertyChangedEventHandler propertyChanged;

        public event EventHandler CanExecuteChanged;
        public MainWindowViewModel mainWindowViewModel;
        private bool canExecute;

        public ChooseCommand(MainWindowViewModel vm)
        {
            mainWindowViewModel = vm;
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            mainWindowViewModel.ChooseGame();
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
        public MainWindowViewModel mainWindowViewModel;
        private bool canExecute;

        public QuitCommand(MainWindowViewModel vm)
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
