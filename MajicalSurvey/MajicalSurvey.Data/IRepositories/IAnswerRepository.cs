using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public interface IAnswerRepository : IRepository<Answers>
    {
        List<Answers> GetAllAnswers(int questionId);

        List<Answers> GetAnswers();

        // void ScoreIncrement(string name);
    }
}
