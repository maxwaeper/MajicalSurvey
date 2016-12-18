using System;
using MajicalSurvey.Data;
using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositories;
using MajicalSurvey.Data.Repositories;
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
    /// Логика взаимодействия для Pass_survey.xaml
    /// </summary>
    public partial class Pass_survey : Window
    {

        List<Questions> list_question = new List<Questions>();
        AnswerRepository ar = new AnswerRepository();
        List<Answers> list_answer = new List<Answers>();
        List<RadioButton> list_radio = new List<RadioButton>();

        int k = 0;

        public Pass_survey()
        {
            InitializeComponent();

            // c.Close();  я пыталась закрыть предыдущее окно 


            foreach (RadioButton r in answer_stackpanel.Children)
            {
                list_radio.Add(r);
            }

            New_question();
        }

        private void Next_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton r in answer_stackpanel.Children) r.IsChecked = false;

            k++;
            New_question();

        }
        public void New_question()
        {
            ChooseSurvey c = new ChooseSurvey();
            var survey = c.s; // это выбранным пользователем опрсник
            surveyName.Text = survey.Name; // Название опросника

            list_question = survey.Questions; // Присваивание вопросов


            questionName.Text = (list_question[k]).Name; // Название вопроса

            list_answer = ar.GetAllAnswers((list_question[k]).Id); // Присваивание ответов

            for (int i = 0; i < list_answer.Count; i++) // Название ответов
            {
                list_radio[i].Content = list_answer[i];
            }

            Counter.Text = string.Format("It is {0} question from {1}", k, list_question.Count);
                
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton r in answer_stackpanel.Children) r.IsChecked = false;
            k--;
            New_question();
        }
    }
}
