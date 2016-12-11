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
            SurveyRepository sur = new SurveyRepository();
            Surveys OneSurvey =  sur.GetSurveyByName(SurveyName);
            QuestionRepository ques = new QuestionRepository();
            List<Questions> l = ques.GetAllQuestions(OneSurvey.Id);
            return l;
        }

        /*public List<Answers> UsersAnswers(string UsersName)
        {
            UsersRepository user = new UsersRepository();
            Users OneUser = user.AnswersOfAUser(UsersName);
            Answers answ = new Answers();
            List<Answers> a = answ.Get
        }*/
    

    }
}
