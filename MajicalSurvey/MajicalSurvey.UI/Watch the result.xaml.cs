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
using System.Windows.Shapes;

namespace MajicalSurvey.UI
{
    /// <summary>
    /// Логика взаимодействия для Watch_the_result.xaml
    /// </summary>
    public partial class Watch_the_result : Window
    {
        public Watch_the_result()
        {
            InitializeComponent();
        }

        private void Show_button_Clicked(object sender, RoutedEventArgs e)
        {
            survey_name.Text = "hi";
            questions_number.Text = "Marina";
            users_number.Text = "Take it easy";

           // if (ComboBox.SelectedItem == all) //do methods for all

            //if (ComboBox.SelectedItem == one) //do methods for one

          
        }
    }
}
