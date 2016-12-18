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
        
        public List<Users> GetAllUsers()
            //возвращает список всех юзеров
        {
            return GetAllElements().ToList();
        }


    }
}
