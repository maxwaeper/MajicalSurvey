
using MajicalSurvey.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class Answers
    {
        [Key]
        public int Id { get; set; }
        public string RadioButtonName { get; set; }
        public string InsertedName { get; set; }
        public int? InsertedNumber { get; set; }
        public List<Users> User { get; set; }
        public Questions Question { get; set; }

    }
}
