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
using MajicalSurvey.Data;


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

        //public int k { get { return k; } set { value = 1; } }

        int k = 1;
        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            string error = "Something is missed";

            if (string.IsNullOrWhiteSpace(Question_name.Text))
            {
                MessageBox.Show("You haven't typed a question", error);
                return;
            }

            if ((Radiobuttons.IsChecked == false) && (Cheakboxes.IsChecked == false) && (String.IsChecked == false))
            {
                MessageBox.Show("You haven't chosen an answer variant", error);
                return;
            }

            listView.Items.Add(new Questions { Id = k, Name = Question_name.Text });

            k++;
            Question_name.Clear();
            foreach (RadioButton r in Variant_stackpanel.Children) r.IsChecked = false;

            // here should go textbox clearing and label hiding

        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            listView.Items.Remove(listView.SelectedItem);

        }

        private void Radiobuttons_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Control item in grid.Children)
            {
                item.Visibility = Visibility.Visible;
            }
        }

        private void Cheakboxes_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Control item in grid.Children)
            {
                item.Visibility = Visibility.Visible;
            }
        }

        private void Item_Selection(object sender, SelectionChangedEventArgs e)
        {
            // Question_name.Text = { Binding Path = (Question)Name};
            Question_name.Text = "hi";
        }
    }
}
