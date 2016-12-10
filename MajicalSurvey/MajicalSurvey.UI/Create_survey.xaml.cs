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
    /// Логика взаимодействия для Create_survey.xaml
    /// </summary>
    public partial class Create_survey : Window
    {
        public Create_survey()
        {
            InitializeComponent();
        }
        int k = 1;
        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
           // listView.Items.Add(new Questions { ID = k, Name = Question_name.Text });

            k++;
            Question_name.Clear();
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            listView.SelectedItems.Remove(0);
        }
    }
}
