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
    /// Логика взаимодействия для ChooseSurvey.xaml
    /// </summary>
    public partial class ChooseSurvey : Window
    {
        public ChooseSurvey()
        {
            InitializeComponent();
        }

        private void ButtonProceed_Click(object sender, RoutedEventArgs e)
        { ChooseSurvey c = new ChooseSurvey();
            Pass_survey next = new Pass_survey();
            next.ShowDialog();
            ButtonProceed.IsCancel = true;
            
                 
        }
    }
}
