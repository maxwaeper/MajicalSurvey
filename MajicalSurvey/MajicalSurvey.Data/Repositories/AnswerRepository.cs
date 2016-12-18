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

        public List<Answers> GetAllAnswers()

        {
            return _context.Answers.Include(x => x.Question).ToList();
        }

      public List<Answers> GetAnswers()
           
        {
            return GetAllElements().ToList();
        }

        public int GetAnswersByName(string name)

        {
            return GetCertainElement(x => x.RadioButtonName == name).Id;
        }

    }
}
