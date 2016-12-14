using MajicalSurvey.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class AnswerRepository : Repository<Answers>, IAnswerRepository
    {
        public List<Answers> GetAllAnswers(int questionId)
        {
            return GetAllElements().Where(x => x.Question.Id == questionId).ToList();
        }
        
    }
}
