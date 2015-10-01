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

namespace LightsOut__WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
                rand = new Random();

                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        grid[r, c] = true;
                    
                    }
                }
                foreach(Rectangle rectangle in paintCanvas.Children)
                {
                    rectangle.Fill = Brushes.White;
                    rectangle.Stroke = Brushes.Black;
                }
            }

            private const int GRID_LENGTH = 300;
            private const int GRID_OFFSET = 45;
            private const int CELL_LENGTH = 100;
            private const int NUM_CELLS = 3;
            private bool[,] grid = new bool[3,3];
            private Random rand;
      

          

       

            private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
              int r = 0;
              int c = 0;
              
              if(sender == rectangle1)
              {
                  
              }
                if(sender == rectangle2)
              {
                  c = 1;
              }
                   if(sender == rectangle3)
              {
                  c = 2;
              }
                   if(sender == rectangle4)
              {
                  r = 1;
                  

              }
                   if(sender == rectangle5)
              {
                  c = 1;
                  r = 1;
              }
                   if(sender == rectangle6)
              {
                  c = 2;
                  r = 1;
              }
                   if(sender == rectangle7)
              {
                  c = 0;
                  r = 2;
              }
                   if(sender == rectangle8)
              {
                  c = 1;
                  r = 2;
              }
                   if(sender == rectangle9)
              {
                  c = 2;
                  r = 2;
              }

                for (int i = r - 1; i <= r + 1; i++)
                    for (int j = c - 1; j <= c + 1; j++)
                        if (i >= 0 && i < NUM_CELLS && j >= 0 && j < NUM_CELLS)
                            grid[i, j] = !grid[i, j];

                if (PlayerWon())
                {
                    // Display winner dialog box
                    DrawGrid();
                    MessageBox.Show(this, "Congratulations! You've won!", "Lights Out!");
                    return;
                } 

                DrawGrid();
                
            }

            private bool PlayerWon()
            {
                bool winCondition = true;

                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (grid[r,c])
                        {
                            winCondition = false;
                            return winCondition;
                        }
                    }
                }
                return winCondition;
            }


            private void DrawGrid()
            {
                int index = 0;

                // Set each rectangle’s color
                for (int r = 0; r < NUM_CELLS; r++)
                    for (int c = 0; c < NUM_CELLS; c++)
                    {
                        Rectangle rect = paintCanvas.Children[index] as Rectangle;
                        index++;
                        if (grid[r, c])
                        {
                            // On
                            rect.Fill = Brushes.White;
                            rect.Stroke = Brushes.Black;
                        }
                        else
                        {
                            // Off
                            rect.Fill = Brushes.Black;
                            rect.Stroke = Brushes.White;
                        }
                    }
            }
            private void closeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                Application.Current.Shutdown();
            }

         

            
            private void helpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                AboutWindow about = new AboutWindow();
                about.ShowDialog();
            }

            private void newCommand_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                for (int r = 0; r < NUM_CELLS; r++)
                    for (int c = 0; c < NUM_CELLS; c++)
                        grid[r, c] = rand.Next(2) == 1;
                DrawGrid();
            }


            
     }
}

