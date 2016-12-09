using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class SurveyRepository : Repository<Surveys>, ISurveyRepository
    {
        public List<Surveys> GetAllSurveys()
        {
            return GetAllElements().ToList();
        }

        public Surveys GetSurveyByName(string name)
        {
            return GetCertainElement(x => x.Name == name);
        }
    }
}
