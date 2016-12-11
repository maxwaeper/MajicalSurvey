using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public interface IAnswerRepository
    {
        List<Answers> GetAllAnswers(int questionId);

       // void ScoreIncrement(string name);
    }
}
