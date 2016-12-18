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
    /// Логика взаимодействия для ChooseSurvey.xaml
    /// </summary>
    public partial class ChooseSurvey : Window
    {
        ISurveyRepository surveyRepo; 
        public ChooseSurvey()
        {
            InitializeComponent();
            surveyRepo = new SurveyRepository();
           
            var surveysList = surveyRepo.GetAllSurveys();
            survey_listview.ItemsSource = surveysList;
        }

        public void ButtonProceed_Click(object sender, RoutedEventArgs e)
        {
            Surveys s = new Surveys();
            var survey = survey_listview.SelectedItem as Surveys;
            try
            {
                s = surveyRepo.GetSurveyByName(survey.Name);

            }
            catch (NullReferenceException)
            {

                MessageBox.Show("You haven't chosen any survey","Oops");
                return;
            }
            var userName = TextBoxEnterName.Text;
            Pass_survey next = new Pass_survey(s,userName);
            next.ShowDialog();
        }
    }
}
