using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class Surveys
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Questions> Questions { get; set; }
    }
}
