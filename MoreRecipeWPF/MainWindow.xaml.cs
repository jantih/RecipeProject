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

namespace MoreRecipeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newIngredient_Click(object sender, RoutedEventArgs e)
        {
            NewIngredient ingredientWindow = new();
            ingredientWindow.Show();
        }

        private void showHistory_Click(object sender, RoutedEventArgs e)
        {
            History showHistory = new();
            showHistory.Show();
        }

        private void addNewRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void discardNewRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void planRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
