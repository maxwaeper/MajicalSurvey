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
        public Watch_the_result()
        {
            InitializeComponent();
        }
        ISurveyRepository surveyRepo = new SurveyRepository();
        IQuestionRepository questionRepo = new QuestionRepository();
        MethodsForStatistics methods = new MethodsForStatistics();

        private void Show_button_Clicked(object sender, RoutedEventArgs e)
        {

            if (ComboBox.SelectedItem == all)
            //do methods for all
            {
                OverallData.Text = "Tne namber of surveys: " + surveyRepo.GetAllSurveys().Count().ToString()+"\r\n"+
                    "The number of surveys for a user: "+ methods.AllUsers().Count().ToString() + "\r\n" +
                    "The avarege number of surveys for a user: " + 
                    (surveyRepo.GetAllSurveys().Count()/ methods.AllUsers().Count()).ToString();
                //+подробнее в табличке в DataGrid в виде: Survey_Name ---- Users namber
                //сортировка по популярности
            }

            if (ComboBox.SelectedItem == one)
            //do methods for one
            {
                //здесь должна быть проверка на то, что введеное название опросника существует 
                OverallData.Text = "Survey's name: " + TextBoxForSurveyName.Text + "\r\n" +
                    "The number of its questions: " + questionRepo.GetAllQuestions(TextBoxForSurveyName.Text).Count().ToString() +
                    "\r\n"+"The number of people who have answered the survey: " + 
                    methods.UsersOfSurvey(TextBoxForSurveyName.Text).Count().ToString();
                //+подробнее в табличк в DataGrid в виде: Вопрос---варианты ответов --- кол-во ответивших на данный вариант ответа
                //---доля в отношении ко всем вариантам ответа ---%
                //(?) самые популярные варианты ответов среди пользователей
            }

          
        }
    }
}
