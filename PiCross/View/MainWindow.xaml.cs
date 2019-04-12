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

namespace View
{
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
            var puzzle = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
                );
            var facade = new PiCrossFacade();
            var playablePuzzle = facade.CreatePlayablePuzzle(puzzle);

            playablePuzzle.Grid[new Vector2D(0, 0)].Contents.Value = Square.FILLED;
            playablePuzzle.Grid[new Vector2D(0, 0)].Contents.Value = Square.FILLED;

            PicrossControl.Grid = playablePuzzle.Grid;
            PicrossControl.RowConstraints = playablePuzzle.RowConstraints;

        }
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
