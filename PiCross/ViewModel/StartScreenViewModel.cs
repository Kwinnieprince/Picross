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
            this.Start = new EasyCommand(() => this.vm.StartGame());
            this.Choose = new EasyCommand(() => this.vm.ChooseGame());
            this.QuitCommand = new EasyCommand(() => this.vm.CloseWindow());
        }

        private MainWindowViewModel vm { get; }

        public ICommand Start { get; }

        public ICommand Choose { get; }

        public ICommand QuitCommand { get; }

        public event PropertyChangedEventHandler propertyChanged;
    }
}
