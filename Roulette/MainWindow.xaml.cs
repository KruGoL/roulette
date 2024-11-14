using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Roulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitNumbers();
        }
        private void InitNumbers()
        {
            int[] blackNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            //Columns
            for (int i = 0; i < 12; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                RouletteNumbers.ColumnDefinitions.Add(column);
            }

            //Rows
            for (int i = 0; i < 3; i++)
            {
                RowDefinition row = new RowDefinition();
                RouletteNumbers.RowDefinitions.Add(row);
            }

            //Numbers
            int number = 1;
            for (int col = 0; col < 12; col++)
            {
                for (int row = 2; row > -1; row--)
                {

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = number.ToString();
                    textBlock.FontSize = 20;

                    Border border = new Border();

                    if (blackNumbers.Contains(number))
                    {
                        border.Background = new BrushConverter().ConvertFrom("#0E1406") as SolidColorBrush;
                        border.BorderBrush = new BrushConverter().ConvertFrom("#3D826C") as SolidColorBrush;
                    }
                    else {
                        border.Background = new BrushConverter().ConvertFrom("#BC1318") as SolidColorBrush;
                        textBlock.Foreground = Brushes.Black;
                    }

                    border.Child = textBlock;

                    RouletteNumbers.Children.Add(border);

                    Grid.SetColumn(border, col);
                    Grid.SetRow(border, row);

                    number++;
                }
            }
        }
    }
}
