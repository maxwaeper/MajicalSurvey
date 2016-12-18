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
        public List<string> Answers { get; set; }
        public List<int> Chosen { get; set; }
        public List<int> Proportion { get; set; }
        public List<string> Persentage { get; set; }
    }
}
