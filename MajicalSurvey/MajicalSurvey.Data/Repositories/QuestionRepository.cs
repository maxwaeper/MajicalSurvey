using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MajicalSurvey.Data.Entities;

namespace MajicalSurvey.Data
{
    public class QuestionRepository : Repository<Questions>, IQuestionRepository
    {
        private Context _context;

        public QuestionRepository()
        {
            _context = new Context();
        }

        public List<Questions> GetAllQuestions(string name)
            //по названию опросника возвращает список вопросов
        {
            return _context.Questions.Include(x => x.Survey).Where(y=>y.Survey.Name==name).ToList();
        }

        public int GetQuestionByName(string name)
            //по вопросу возвращает его айди
        {
            return GetCertainElement(x => x.Name == name).Id;
        }



        
    }
}
