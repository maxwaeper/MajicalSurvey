using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.Repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public Users AnswersOfAUser(string name)
        {
            return GetCertainElement(x => x.Name == name);
        }

        //public List<Users> GetUsersAnswers(int answersId)
        //{
        //    return GetAllElements().Where(x => x.Answer.Id == answersId).ToList();
        //}

    }
}
