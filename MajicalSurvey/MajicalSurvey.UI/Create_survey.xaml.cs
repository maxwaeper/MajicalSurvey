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
using System.Globalization;

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

        ISurveyRepository _survey = new SurveyRepository();
        IQuestionRepository _question = new QuestionRepository();
        IAnswerRepository _answer = new AnswerRepository();


        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            Questions q = new Questions();
            Valide_info();
            q.Name = Question_name.Text;
            listView.Items.Add(q);
            list_quest.Add(new Questions { Name = Question_name.Text });

            foreach (TextBox t in stackpanel_textboxes.Children)
            {
                if (!string.IsNullOrWhiteSpace(t.Text))
                {
                    list_answers.Add(new Answers
                    {
                        RadioButtonName = t.Text,
                        Question = list_quest.Last()
                    });
                }

            }


            Clear_info();
            survey_textblock.Text = "You can rename your survey";
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {

            var item = listView.SelectedItem as Questions;
            list_quest.RemoveAll(x => x.Name == item.Name);
            list_answers.RemoveAll(x => x.Question.Name == item.Name);
            listView.Items.Remove(listView.SelectedItem);

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
            _survey.Insert(new Surveys { Name = Survey_name.Text, Questions = list_quest });

            foreach (var item in list_quest)
            {
                _question.Insert(item);
            }

            foreach (var item in list_answers)
            {
                _answer.Insert(item);
            }
            _answer.Save();
            MessageBox.Show("Survey is created", "Well done!");
            Close();

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

            if ((Radiobuttons.IsChecked == false) && (Checkboxes.IsChecked == false) && (String.IsChecked == false))
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

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (listView.SelectedItem != null)
            {
                Clear_info();
                ButtonSaveChanges.IsEnabled = true;
                grid.Visibility = Visibility.Visible;
                var name = listView.SelectedItem as Questions;
                List<Answers> list = list_answers.FindAll(x => x.Question.Name == name.Name);
                var i = 0;
                foreach (var item in list_quest)
                {
                    if (item.Name == name.Name)
                        Question_name.Text = item.Name;
                }
                foreach (TextBox t in stackpanel_textboxes.Children)
                {
                    if (i < list.Count)
                    {
                        if (list[i].Question.Name == name.Name)
                            t.Text = list[i].RadioButtonName;
                    }
                    else
                        t.Text = null;
                    i++;
                }

                Radiobuttons.IsChecked = true;
            }
        }

        private void Save_Changes_Clicked(object sender, RoutedEventArgs e)
        {
            var remove = listView.SelectedItem as Questions;
            var index = list_quest.FindIndex(x => x.Name == remove.Name);
            listView.Items.RemoveAt(index);
            listView.Items.Add(new Questions { Name = Question_name.Text });
            list_quest.RemoveAt(index);
            list_answers.RemoveAll(x => x.Question.Name == remove.Name);
            Valide_info();

            list_quest.Insert(index, new Questions { Name = Question_name.Text });

            foreach (TextBox t in stackpanel_textboxes.Children)
            {
                if (!string.IsNullOrWhiteSpace(t.Text))
                {
                    list_answers.Add(new Answers
                    {
                        RadioButtonName = t.Text,
                        Question = list_quest[index]
                    });
                }

            }
            Clear_info();
            ButtonSaveChanges.IsEnabled = false;
        }
    }
}