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
            //по номеру вопроса возвращает список вариантов ответов
        {
            return GetAllElements().Where(x => x.Question.Id == questionId).ToList();
        }

      public List<Answers> GetAnswers()
            //возвращает все варианты ответов для всех опросников
        {
            return GetAllElements().ToList();
        }     
    }
}
