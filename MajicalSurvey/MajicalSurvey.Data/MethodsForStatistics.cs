using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    class MethodsForStatistics 
    {
        public List<Questions> QuestionsBySurvey(string SurveyName)
        {
            ISurveyRepository sur = new SurveyRepository();
            Surveys OneSurvey =  sur.GetSurveyByName(SurveyName);
            IQuestionRepository ques = new QuestionRepository();
            List<Questions> l = ques.GetAllQuestions(OneSurvey.Id);
            return l;
        }

        public List<Answers> UsersAnswers(string UsersName)
        {
            UsersRepository user = new UsersRepository();
            Users OneUser = user.AnswersOfAUser(UsersName);
            IAnswerRepository answ = new AnswerRepository();
            List<Answers> a = answ.GetAllAnswers(OneUser.Id);
            return a;
        }

        public int NuberOfAnswersForUser (List<Answers> ans)
        {
            int k = ans.Count();
            return k;
        }

        /*public List<Users> UsersOfServey (string surveyname)
        {
            ISurveyRepository sur = new SurveyRepository();
            Surveys OneSurvey = sur.GetSurveyByName(surveyname);
            IQuestionRepository ques = new QuestionRepository();
            List<Questions> l = ques.GetAllQuestions(OneSurvey.Id);
            foreach (var question in l)
            {
                if ( )
            }
            }
            */

        

    }
}
