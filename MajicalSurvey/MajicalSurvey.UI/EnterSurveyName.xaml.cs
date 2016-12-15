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
    /// Логика взаимодействия для EnterSurveyName.xaml
    /// </summary>
    public partial class EnterSurveyName : Window
    {
        IRepository<Surveys> survey;
        public EnterSurveyName()
        {
            InitializeComponent();
            survey = new Repository<Surveys>();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            survey.Insert(new Surveys { Name = TextBoxSurveyName.Text });
            Create_survey create = new Create_survey();
            create.ShowDialog();
        }
    }
}
