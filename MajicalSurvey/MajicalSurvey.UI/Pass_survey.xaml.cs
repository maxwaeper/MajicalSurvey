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

        
        IAnswerRepository ar;
        IQuestionRepository qr;
        IUsersRepository ur;
        public Surveys S { get; set; }
        public List<Questions> list_question { get; set; } = new List<Questions>();
        public List<Answers> list_answer { get; set; } = new List<Answers>();
        public List<Answers> user_list_answer { get; set; } = new List<Answers>();
        public List<RadioButton> list_radio { get; set; } = new List<RadioButton>();

        public int k { get; set; }

        public Pass_survey(Surveys s)
        {
            InitializeComponent();
            ar = new AnswerRepository();
            ur = new UsersRepository();
            qr = new QuestionRepository();
            foreach (RadioButton r in answer_stackpanel.Children)
            {
                list_radio.Add(r);
            }
            S = s;

            New_question();
        }

        private void Next_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton r in answer_stackpanel.Children) r.IsChecked = false;

            k++;
            New_question();

            Save_answer();
           
        }
        public void New_question()
        {

            var survey = S; // это выбранный пользователем опрсник
            surveyName.Text = survey.Name; // Название опросника

            list_question = qr.GetAllQuestions(S.Name); // Присваивание вопросов
            Number.Text = k.ToString();

            questionName.Text = (list_question[k]).Name; // Название вопроса

            list_answer = ar.GetAllAnswers((list_question[k]).Id)
                .Where(x=>x.Question.Name == list_question[k].Name).ToList(); // Присваивание ответов

            for (int i = 0; i < list_answer.Count; i++) // Название ответов
            {
                list_radio[i].Content = list_answer[i].RadioButtonName;
            }

            Counter.Text = string.Format("It is {0} question from {1}", k, list_question.Count);

            if (k + 1 == list_question.Count)
            {
                next.Visibility = Visibility.Collapsed;
                Complete.Visibility = Visibility.Visible;

            }

        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton r in answer_stackpanel.Children) r.IsChecked = false;
            k--;
            New_question();
            Save_answer();
        }

        private void Complete_Clicked(object sender, RoutedEventArgs e)
        {
        //    //отправка данных в бд

        //    foreach (Answers a in list_answer) ar.Insert(a);

        //    ChooseSurvey c = new ChooseSurvey();
        //    var user = c.u; // создание пользователя
        //    user.Answers = list_answer;
        //    ur.Insert(user);

        //    ur.Save();

        //    MessageBox.Show("Survey is passed", "Well done!");
        //    Close();
        }

        public void Save_answer()
        {
            foreach (RadioButton r in answer_stackpanel.Children)
            {
                if (r.IsChecked == true)
                {
                    Answers a = new Answers();
                    a.RadioButtonName = r.Content.ToString();
                    a.Question = list_question[k];
                    user_list_answer.Insert(k, a);
                }
            }
        }
    }
}
