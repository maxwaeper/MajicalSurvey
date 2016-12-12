﻿using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.Repositories
{
    public class UsersRepository : Repository<Users>, IUsers
    {
        public Users AnswersOfAUser(string name)
        {
            return GetCertainElement(x => x.Name == name);
        }
    }
}