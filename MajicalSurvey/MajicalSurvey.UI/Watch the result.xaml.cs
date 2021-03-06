﻿using MajicalSurvey.Data;
using MajicalSurvey.Data.Entities;
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
        IAnswerRepository answersRepo;
        
        public Watch_the_result()
            
        {
            InitializeComponent();
            surveyRepo = new SurveyRepository();
            questionRepo = new QuestionRepository();
            usersRepo = new UsersRepository();
            answersRepo = new AnswerRepository();

            var surveysList = surveyRepo.GetAllSurveys();
          
            foreach (var item in surveysList)
            {
                Survey_choice.Items.Add(item.Name);
            }


        }
        

        private void Show_button_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                MethodsForStatistics methods = new MethodsForStatistics();
                OverallData.Visibility = Visibility.Visible;
                var surveysList = surveyRepo.GetAllSurveys();

                if (ComboBox.SelectedItem == all)

                {
                    data_one.Visibility = Visibility.Hidden;
                    data_all.Visibility = Visibility.Visible;
                    first.Text = "The number of surveys:";
                    second.Text = "The number of unique users:";

                    first_n.Text = surveyRepo.GetAllSurveys().Count().ToString();
                    second_n.Text = usersRepo.GetAllUsers().Count().ToString();


                    List<ShowResultsInDG> print = new List<ShowResultsInDG>();

                    foreach (var survey in surveysList)
                    {
                        print.Add(new ShowResultsInDG
                        {
                            Count = survey.Id,
                            Name = survey.Name,
                            Users = methods.UsersOfSurvey(survey.Name).Count()
                        });

                    }
                    data_all.ItemsSource = print;



                }

                if (ComboBox.SelectedItem == one)

                {
                    data_all.Visibility = Visibility.Hidden;
                    data_one.Visibility = Visibility.Visible;


                    data_one.Visibility = Visibility.Visible;

                    first.Text = "Survey's name:";
                    second.Text = "The number of its questions:";
                    third.Text = "The number of people who have answered the survey:";

                    try
                    {
                        first_n.Text = Survey_choice.SelectedItem.ToString();
                    }
                    catch (NullReferenceException)
                    {

                        MessageBox.Show("You haven't chosen any survey");
                        return;
                    }

                    second_n.Text = questionRepo.GetAllQuestions(Survey_choice.SelectedItem.ToString()).Count().ToString();
                    third_n.Text = methods.UsersOfSurvey(Survey_choice.SelectedItem.ToString()).Count().ToString();
                    List<Questions> questionslist = questionRepo.GetAllQuestions(Survey_choice.SelectedItem.ToString());
                    List<ShowResultsForOneInDG> print = new List<ShowResultsForOneInDG>();

                    foreach (var question in questionslist)
                    {
                        int questionID = questionRepo.GetQuestionByName(question.Name);
                        List<Answers> answers = answersRepo.GetAllAnswers().Where(x => x.Question.Id == question.Id).ToList();


                        foreach (var answer in answers)
                        {
                            int answersID = answersRepo.GetAnswersByName(answer.RadioButtonName);
                            float usersnum = methods.GetUserssByAnswersId(answersID).Count();
                            float propor = 0;

                            try
                            {
                                propor = usersnum / methods.ListForProportion(questionID).Count();
                            }
                            catch (DivideByZeroException)
                            {

                                propor = 0;
                            }



                            string percent = (propor * 100).ToString() + "%";
                            print.Add(new ShowResultsForOneInDG
                            {
                                Question = question.Name,
                                Answers = answer.RadioButtonName,
                                Chosen = usersnum,
                                Proportion = propor,
                                Percentage = percent
                            });

                        }

                    }

                    data_one.ItemsSource = print;



                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry this part is still under development");
            }
        }


        private void all_Selected(object sender, RoutedEventArgs e)
        {
            Survey_choice.IsEnabled = false;
        }

        private void one_Selected(object sender, RoutedEventArgs e)
        {
            Survey_choice.IsEnabled = true;

        }
    }
}
