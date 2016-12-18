using MajicalSurvey.Data;
using MajicalSurvey.Data.IRepositories;
using MajicalSurvey.Data.Repositories;
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
        IUsersRepository usersRepo;
        public Watch_the_result()
        {
            InitializeComponent();
            surveyRepo = new SurveyRepository();
            questionRepo = new QuestionRepository();
            usersRepo = new UsersRepository();

            

            //foreach (Surveys s in surveysList)
            //{
            //    ComboBoxItem i = new ComboBoxItem();
            //    i.Content = s.Name;
                
            //}

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
                second_n.Text = usersRepo.GetAllUsers().Count().ToString();
                
                try
                {
                     third_n.Text = (surveyRepo.GetAllSurveys().Count() / usersRepo.GetAllUsers().Count()).ToString();
                }
                catch (DivideByZeroException)
                {

                    third_n.Text = "0";
                }

                List<DataGridViewAllSurveys> listAll = new List<DataGridViewAllSurveys>();

                foreach (var item in surveysList)
                {
                    listAll.Add(new DataGridViewAllSurveys
                    {
                        Id = item.Id, SurveyName = item.Name, UsersCount = methods.UsersOfSurvey(item.Name).Count()
                    });
                }

                data_all.ItemsSource = listAll;
               
               

                //+подробнее в табличке в DataGrid в виде: Survey_Name ---- Users namber
                //сортировка по популярности
            }

            if (ComboBox.SelectedItem == one)
            //do methods for one
            {
                foreach (var item in surveysList)
                {
                    Survey_choice.Items.Add(item.Name);
                }

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


                //first_n.Text = TextBoxForSurveyName.Text;
                //second_n.Text = questionRepo.GetAllQuestions(TextBoxForSurveyName.Text).Count().ToString();
                //third_n.Text = methods.UsersOfSurvey(TextBoxForSurveyName.Text).Count().ToString();

              

                //+подробнее в табличк в DataGrid в виде: Вопрос---варианты ответов --- кол-во ответивших на данный вариант ответа
                //---доля в отношении ко всем вариантам ответа ---%
                //(?) самые популярные варианты ответов среди пользователей

            }
        }

    }
}
