using MajicalSurvey.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MajicalSurvey.Data
{
    public class AnswerRepository : Repository<Answers>, IAnswerRepository
    {
        private Context _context;

        public AnswerRepository()
        {
            _context = new Context();
        }

        public List<Answers> GetAllAnswers()//delete questionId cause os uselessnes
            //по номеру вопроса возвращает список вариантов ответов
        {
            return _context.Answers.Include(x => x.Question).ToList();
        }

      public List<Answers> GetAnswers()
            //возвращает все варианты ответов для всех опросников
        {
            return GetAllElements().ToList();
        }

        public int GetAnswersByName(string name)
        //по вопросу возвращает его айди
        {
            return GetCertainElement(x => x.RadioButtonName == name).Id;
        }

    }
}
