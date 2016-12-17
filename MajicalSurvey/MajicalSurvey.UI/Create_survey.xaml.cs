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

        List<Questions> list_quest = new List<Questions>();
        List<Answers> list_answers = new List<Answers>();

        Surveys s = new Surveys();
        Questions q = new Questions();
        Answers a = new Answers();

        ISurveyRepository _survey = new SurveyRepository();
        IRepository<Surveys> ss = new SurveyRepository();
        IQuestionRepository _question = new QuestionRepository();
        IAnswerRepository _answer = new AnswerRepository();


        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            // !!!!!!!!!!!!!!!!! Шо это?
            EnterSurveyName survey = new EnterSurveyName();

            Valide_info();          

            q.Name = Question_name.Text;
            q.Survey = s;
            list_quest.Add(q);

            listView.Items.Add(q);

           
            foreach (TextBox t in stackpanel_textboxes.Children)
            {
                if (!string.IsNullOrWhiteSpace(t.Text))
                {
                    a.RadioButtonName = t.Text;
                    a.Question = q;

                    list_answers.Add(a);
                }
                        
            }

            Clear_info();
            survey_textblock.Text = "You can rename your survey";

           // listView.ItemsSource = questionRepo.GetAllQuestions(survey.SurveyName);

        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            listView.Items.Remove(listView.SelectedItem);

            // ещё здесь нужно будет удалить вопрос с ответами из листов, только вот как ? :(
            //list_quest.Remove()

        }

        private void Radiobuttons_Checked(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Visible;
        }

        private void Current_version_exeption(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, this option is not available in current version of application", "Current version exception");
            foreach (RadioButton r in Variant_stackpanel.Children) r.IsChecked = false;
        }

        private void Finish_Clicked(object sender, RoutedEventArgs e)
        {
            s.Name = Survey_name.Text;
            s.Questions = list_quest;

            Survey_name.Clear();

           //_survey
        }

        public void Clear_info()
        {
            Question_name.Clear();
            foreach (RadioButton r in Variant_stackpanel.Children) r.IsChecked = false;

            foreach (TextBox t in stackpanel_textboxes.Children) t.Clear();

            grid.Visibility = Visibility.Hidden;

        }

        public void Valide_info()
        {
            string error = "Something is missed";

            if (string.IsNullOrWhiteSpace(Survey_name.Text))
            {
                MessageBox.Show("You haven't named a survey", error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Question_name.Text))
            {
                MessageBox.Show("You haven't written a question", error);
                return;
            }

            if ((Radiobuttons.IsChecked == false) && (Cheakboxes.IsChecked == false) && (String.IsChecked == false))
            {
                MessageBox.Show("You haven't chosen an answer type", error);
                return;
            }

            int c = 0;
            foreach (TextBox t in stackpanel_textboxes.Children)
            {
                if (!string.IsNullOrWhiteSpace(t.Text)) break;
                c++;
            }

            if (c > 9)
            {
                MessageBox.Show("You haven't written any answers", error);
                return;
            }
        }
    }
}
