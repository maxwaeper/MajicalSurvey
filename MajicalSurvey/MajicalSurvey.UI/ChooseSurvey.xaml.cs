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
    /// Логика взаимодействия для ChooseSurvey.xaml
    /// </summary>
    public partial class ChooseSurvey : Window
    {
        ISurveyRepository surveyRepo = new SurveyRepository();

        public SurveyRepository sr { get; set; }
        public Surveys s { get; set; }

        public ChooseSurvey()
        {
            InitializeComponent();

            var surveysList = surveyRepo.GetAllSurveys();

            foreach (Surveys item in surveysList)
            {
                survey_listview.Items.Add(item.Name);
            }
        }

        public Surveys ButtonProceed_Click(object sender, RoutedEventArgs e)
        {

            s = sr.GetSurveyByName(survey_listview.SelectedItem.ToString());


            Pass_survey next = new Pass_survey();
            next.ShowDialog();
            //ButtonProceed.IsCancel = true;
            return s;
        }
    }
}
