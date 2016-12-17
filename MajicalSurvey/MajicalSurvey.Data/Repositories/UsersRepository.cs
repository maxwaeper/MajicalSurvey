using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data.Repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        //private Context _context;

        //public UsersRepository()
        //{
        //    _context = new Context();
        //}

        //public Users AnswersOfAUser(string name)
        //{
        //    return GetCertainElement(x => x.Name == name);
        //}

        public List<Users> GetAllUsers()
            //возвращает список всех юзеров
        {
            return GetAllElements().ToList();
        }

        //public List<Answers> GetAnswersOfUser(int id)
        //{
        //    return GetAllElements().Where()
        //}

        //public List<Users> GetUsersAnswers(int answersId)
        //{
        //    return GetAllElements().Where(x => x.Answer.Id == answersId).ToList();
        //}

    }
}
