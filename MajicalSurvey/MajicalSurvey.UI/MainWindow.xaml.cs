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

namespace MajicalSurvey.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void statistic_Clicked(object sender, RoutedEventArgs e)
        {
            Watch_the_result watch = new Watch_the_result();
            watch.ShowDialog();
        }

        private void create_survey_Clicked(object sender, RoutedEventArgs e)
        {
            Create_survey create = new Create_survey();
            create.ShowDialog();
        }

        private void pass_survey_Clicked(object sender, RoutedEventArgs e)
        {
            ChooseSurvey pass = new ChooseSurvey();
             pass.ShowDialog();
        }
    }
}
