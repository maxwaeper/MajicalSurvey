using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class QuestionRepository : Repository<Questions>, IQuestionRepository
    {
        public List<Questions> GetAllQuestions(int surveyId)
        {
            return GetAllElements().Where(x=>x.Survey.Id==surveyId).ToList();
        }

        public Questions GetQuestionByName(string name)
        {
            return GetCertainElement(x => x.Name == name);
        }

        
    }
}
