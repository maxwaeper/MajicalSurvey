using MajicalSurvey.Data;
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
        ISurveyRepository surveyRepo;
        IQuestionRepository questionRepo;
        public Watch_the_result()
        {
            InitializeComponent();
            surveyRepo = new SurveyRepository();
            questionRepo = new QuestionRepository();
        }

        private void Show_button_Clicked(object sender, RoutedEventArgs e)
        {
            MethodsForStatistics methods = new MethodsForStatistics();
            OverallData.Visibility = Visibility.Visible;
            var surveysList = surveyRepo.GetAllSurveys();

            if (ComboBox.SelectedItem == all)
            //do methods for all
            {
                data_all.Visibility = Visibility.Visible;
                first.Text = "The number of surveys:";
                second.Text = "The number of surveys for a user:";
                third.Text = "The avarege number of surveys for a user:";

                first_n.Text = surveyRepo.GetAllSurveys().Count().ToString();
                second_n.Text = methods.AllUsers().Count().ToString();

                try
                {
                     third_n.Text = (surveyRepo.GetAllSurveys().Count() / methods.AllUsers().Count()).ToString();
                }
                catch (DivideByZeroException)
                {

                    third_n.Text = "0";
                }
                foreach (var item in surveysList)
                {
                    data_all.ItemsSource = item.Id + item.Name + methods.UsersOfSurvey(item.Name);
                }
               
                //OverallData.Text = "Tne namber of surveys: " + surveyRepo.GetAllSurveys().Count().ToString()+"\r\n"+
                //    "The number of surveys for a user: "+ methods.AllUsers().Count().ToString() + "\r\n" +
                //    "The avarege number of surveys for a user: " + 
                //    (surveyRepo.GetAllSurveys().Count()/ methods.AllUsers().Count()).ToString();

                //+подробнее в табличке в DataGrid в виде: Survey_Name ---- Users namber
                //сортировка по популярности
            }

            if (ComboBox.SelectedItem == one)
            //do methods for one
            {
                //здесь должна быть проверка на то, что введеное название опросника существует 

                // проверка работает, бд пустая
                //int k = 0;

                //foreach (Surveys s in surveyRepo.GetAllSurveys())
                //{
                //    if (s.Name == TextBoxForSurveyName.Text) k++;
                //}

                //if (k != 1)
                //{
                //    MessageBox.Show("There are no survey with such name", "Something is missed");
                //    return;
                //}

                data_one.Visibility = Visibility.Visible;

                first.Text = "Survey's name:";
                second.Text = "The number of its questions:";
                third.Text = "The number of people who have answered the survey:";


                first_n.Text = TextBoxForSurveyName.Text;
                second_n.Text = questionRepo.GetAllQuestions(TextBoxForSurveyName.Text).Count().ToString();
                third_n.Text = methods.UsersOfSurvey(TextBoxForSurveyName.Text).Count().ToString();

                //OverallData.Text = "Survey's name: " + TextBoxForSurveyName.Text + "\r\n" +
                //    "The number of its questions: " + questionRepo.GetAllQuestions(TextBoxForSurveyName.Text).Count().ToString() +
                //    "\r\n"+"The number of people who have answered the survey: " + 
                //    methods.UsersOfSurvey(TextBoxForSurveyName.Text).Count().ToString();

                //+подробнее в табличк в DataGrid в виде: Вопрос---варианты ответов --- кол-во ответивших на данный вариант ответа
                //---доля в отношении ко всем вариантам ответа ---%
                //(?) самые популярные варианты ответов среди пользователей

            }
        }
    }
}
