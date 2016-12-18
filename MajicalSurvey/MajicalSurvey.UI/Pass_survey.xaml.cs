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
        IQuestionRepository questionRepo;

        public Pass_survey(Surveys s)
        {
            InitializeComponent();
            questionRepo = new QuestionRepository();
            // c.Close();  я пыталась закрыть предыдущее окно 
            foreach (RadioButton r in answer_stackpanel.Children)
            {
                list_radio.Add(r);
            }
            s.Questions = questionRepo.GetAllQuestions(s.Name);
            surveyName.Text = s.Name;
            list_question = s.Questions;



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
