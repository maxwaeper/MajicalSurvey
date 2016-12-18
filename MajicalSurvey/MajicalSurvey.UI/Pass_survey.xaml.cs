using System;
using MajicalSurvey.Data;
using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositoties;
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

        public Pass_survey()
        {
            InitializeComponent();

            ChooseSurvey c = new ChooseSurvey();
            // c.Close();  я пыталась закрыть предыдущее окно 

            var survey = c.s; // это выбранным пользователем опрсник


            foreach (RadioButton r in answer_stackpanel.Children)
            {
                list_radio.Add(r);
            }

            surveyName.Text = survey.Name;
            list_question = survey.Questions;



            questionName.Text = (list_question[0]).Name;

            list_answer = ar.GetAllAnswers((list_question[0]).Id);

            for (int i = 0; i < list_answer.Count; i++)
            {
                list_radio[i].Content = list_answer[i];
            }

        }

        private void Next_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton r in answer_stackpanel.Children) r.IsChecked = false;

        }
    }
}
