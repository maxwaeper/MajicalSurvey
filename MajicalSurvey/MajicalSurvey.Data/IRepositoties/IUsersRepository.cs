﻿using MajicalSurvey.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.IRepositoties
{
    public interface IUsersRepository
    {
        //List<Users> GetUsersAnswers(int answersId);

        Users AnswersOfAUser(string name);
    }
}
