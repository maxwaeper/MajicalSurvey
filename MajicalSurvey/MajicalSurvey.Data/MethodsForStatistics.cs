using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositoties;
using MajicalSurvey.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class MethodsForStatistics 
    {
        IUsersRepository user;
        IAnswerRepository answer;
        IQuestionRepository question;

        public MethodsForStatistics()
        {
            user = new UsersRepository();
            answer = new AnswerRepository();
            question = new QuestionRepository();

        }
        //public List<Questions> QuestionsBySurvey(string SurveyName)
        //{
        //    ISurveyRepository sur = new SurveyRepository();
        //    Surveys OneSurvey =  sur.GetSurveyByName(SurveyName);
        //    IQuestionRepository ques = new QuestionRepository();
        //    List<Questions> l = ques.GetAllQuestions(OneSurvey.Id);
        //    return l;
        //}


        public List<Answers> UsersAnswers(string UsersName)
        { 
                Users OneUser = user.AnswersOfAUser(UsersName);
                List<Answers> a = answer.GetAllAnswers(OneUser.Id);
                return a;
            
        }


        public int NuberOfAnswersForUser (List<Answers> ans)
        {
            int k = ans.Count();
            return k;
        }


        //public List<Users> UsersOfSurvey(string SurveyName)
        //{
        //    List<Questions> l = question.GetAllQuestions(SurveyName);
        //    List<Users> usersList = new List<Users>();
        //    foreach (var question in l)
        //    {
        //        List<Answers> a = answer.GetAllAnswers(question.Id);
        //        foreach (var answer in a)
        //        {
        //            List<Users> u = user.GetUsersAnswers(answer.Id);
        //            foreach (var item in u)
        //            {
        //                usersList.Add(item);
        //            }
        //        }
        //    }
        //    return usersList;
        //}


        }
}
