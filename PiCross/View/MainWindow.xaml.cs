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
    using static View.Converters.SquareConverter;
    using static View.Converters.BoolConverter;
    using Grid = DataStructures.Grid;
    using size = DataStructures.Size;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
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
}
