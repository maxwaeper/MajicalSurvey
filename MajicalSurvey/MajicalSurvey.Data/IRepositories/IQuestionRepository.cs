using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public interface IQuestionRepository : IRepository<Questions>
    {
        List<Questions> GetAllQuestions(string name);

        int GetQuestionByName(string name);

       // Questions GetQuestionByName(string name);
    }
}
