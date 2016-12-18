using MajicalSurvey.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.IRepositories
{
    public interface IUsersRepository : IRepository<Users>
    {
        //List<Users> GetUsersAnswers(int answersId);
        List<Users> GetAllUsers();

        //Users AnswersOfAUser(string name);

        //List<Users> GetAnswersOfUser(int id);
    }
}
