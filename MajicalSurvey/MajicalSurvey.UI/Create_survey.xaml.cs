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
        IQuestionRepository questionRepo;
        public Create_survey()
        {
            InitializeComponent();
            questionRepo = new QuestionRepository();
        }

        //public int k { get { return k; } set { value = 1; } }

        List<Questions> list_quest = new List<Questions>();
        List<Answers> list_answers = new List<Answers>();
 
        public void Clear_info()
        {
            Question_name.Clear();
            foreach (RadioButton r in Variant_stackpanel.Children) r.IsChecked = false;

            // grid.RowDefinitions.Clear();
            //foreach (Window item in grid.Children)
            //{
            //    (TextBox)item.
            //}
            foreach (TextBox t in stackpanel_textboxes.Children)
            {
                t.Clear();

            }
            grid.Visibility = Visibility.Hidden;
            //for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            //{

            //}

            // here should go textbox clearing and label hiding
        }

        int k = 1;
        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            EnterSurveyName survey = new EnterSurveyName();

            string error = "Something is missed";

            if (string.IsNullOrWhiteSpace(Survey_name.Text))
            {
                MessageBox.Show("You haven't named a survey", error);
                return;
            }

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

            Surveys s = new Surveys();
            Questions q = new Questions();
            Answers a = new Answers();


            

            q.Id = k;
            q.Name = Question_name.Text;
            q.Survey = s;
            list_quest.Add(q);


          //  listView.Items.Add(new Questions { Id = k, Name = Question_name.Text });
            listView.Items.Add(q); 

            /////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            foreach (Control c in stackpanel_textboxes.Children)
            {
                int m = 1;
                if (!string.IsNullOrWhiteSpace(c.ToString()))
                    list_answers.Add(new Answers { Id = 1, RadioButtonName = c.ToString(), Question = k }); 
            }

            k++;

            Clear_info();
            if (k != 1) survey_textblock.Text = "You can rename your survey";

           // listView.ItemsSource = questionRepo.GetAllQuestions(survey.SurveyName);

        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            listView.Items.Remove(listView.SelectedItem);

        }

        private void Radiobuttons_Checked(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Visible;
        }

        private void Cheakboxes_Checked(object sender, RoutedEventArgs e)
        {
            //foreach (Control item in grid.Children)
            //{
            //    item.Visibility = Visibility.Visible;

            //}
            grid.Visibility = Visibility.Visible;
        }

        private void Item_Selection(object sender, SelectionChangedEventArgs e)
        {
            // Question_name.Text = { Binding Path = (Question)Name};
            Question_name.Text = "hi";
        }

        private void String_Checked(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Hidden;
        }

        private void Number_Checked(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Hidden;
        }
    }
}
