using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public interface ISurveyRepository
    {
        Surveys GetSurveyByName(string name);

        List<Surveys> GetAllSurveys();
    }
}
