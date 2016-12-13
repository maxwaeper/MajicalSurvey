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
         
        public List<Answers> GetAnswersForUser (string name)
        {
            return GetAllElements().Where(x => x.Users.Name == name).ToList();
        }
        /*public void ScoreIncrement(string name)
        {
            var score = GetCertainElement(x => x.Name == name);
            score.Score++;
            Save();
        }*/
    }
}
