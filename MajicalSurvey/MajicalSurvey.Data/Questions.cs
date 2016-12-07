﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Answers> Answers { get; set; }
    }
}