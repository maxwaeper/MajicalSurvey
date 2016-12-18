using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Answers> Answers { get; set; }
    }
}
