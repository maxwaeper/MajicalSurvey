using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class ShowResultsForOneInDG
    {
        public string Question { get; set; }
        public string Answers { get; set; }
        public float Chosen { get; set; }
        public float Proportion { get; set; }
        public string Percentage { get; set; }
    }
}
