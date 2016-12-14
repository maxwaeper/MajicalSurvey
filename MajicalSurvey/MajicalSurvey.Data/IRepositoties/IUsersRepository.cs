using MajicalSurvey.Data.Entities;
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
        List<Users> GetAllUsers();

        Users AnswersOfAUser(string name);

        //List<Users> GetAnswersOfUser(int id);
    }
}
