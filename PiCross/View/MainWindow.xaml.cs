using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ViewModel;


namespace View
{
    using System.ComponentModel;
    using System.Globalization;
    using Grid = DataStructures.Grid;
    using size = DataStructures.Size;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            vm = new ViewModel.ViewModelMainWindow();

            this.DataContext = vm;

            PicrossControl.Grid = vm.PlayablePuzzle.Grid;

            PicrossControl.RowConstraints = vm.PlayablePuzzle.RowConstraints;
            PicrossControl.ColumnConstraints = vm.PlayablePuzzle.ColumnConstraints;

        }

        private ViewModel.ViewModelMainWindow vm;
    }

    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }
        public object Empty { get; set; }
        public object Unknown { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;
            if (square == Square.EMPTY)
            {
                return Empty;
            }
            else if (square == Square.FILLED)
            {
                return Filled;
            }
            else
            {
                return Unknown;
            }
        }

        public class Navigator : INotifyPropertyChanged
        {
            private Screen currentScreen;

            public Navigator()
            {
                this.currentScreen = new StartScreen(this);
            }

            public Screen CurrentScreen
            {
                get
                {
                    return CurrentScreen;
                }
                set
                {
                    this.CurrentScreen = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScreen)));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        public abstract class Screen
        {
            protected readonly Navigator navigator;

            protected Screen(Navigator navigator)
            {
                this.navigator = navigator;
            }

            protected void SwitchTo(Screen screen)
            {
                this.navigator.CurrentScreen = screen;
            }
        }

        public class StartScreen : Screen
        {
            public StartScreen(Navigator navigator) : base(navigator)
            {
                GoToChooseScreen = new EasyCommand(() => SwitchTo(new ChooseScreen(navigator)));
            }
            public ICommand GoToChooseScreen { get; }
        }

        public class ChooseScreen : Screen
        {
            public ChooseScreen(Navigator navigator) : base(navigator)
            {
                GoToGameScreen = new EasyCommand(() => SwitchTo(new MainScreen(navigator)));
            }

            public ICommand GoToGameScreen { get; }
        }

        public class MainScreen : Screen
        {
            public MainScreen(Navigator navigator) : base(navigator)
            {
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
