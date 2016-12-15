using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class QuestionRepository : Repository<Questions>, IQuestionRepository
    {
        public List<Questions> GetAllQuestions(string name)
            //по названию опросника возвращает список вопросов
        {
            return GetAllElements().Where(x=>x.Survey.Name==name).ToList();
        }

        public int GetQuestionByName(string name)
            //по вопросу возвращает его айди
        {
            return GetCertainElement(x => x.Name == name).Id;
        }

        
    }
}
