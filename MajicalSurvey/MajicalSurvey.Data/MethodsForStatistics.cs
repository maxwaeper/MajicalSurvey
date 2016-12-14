using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositoties;
using MajicalSurvey.Data.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class MethodsForStatistics 
    {
        private Context context;
        IUsersRepository user;
        IAnswerRepository answer;
        IQuestionRepository question;

        public MethodsForStatistics()
        {
            user = new UsersRepository();
            answer = new AnswerRepository();
            question = new QuestionRepository();
            context = new Context();
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

        public List<Answers> GetUsersAnswersById(int id)
        {
            List<Answers> answers = answer.GetAnswers();
            List<Users> users = user.GetAllUsers();
            List<Answers> newAnswers = new List<Answers>();
            foreach (var item in context.Users.Include(x=>x.Answers))
            {
                if (item.Id == id)
                {
                    foreach (var k in item.Answers)
                    {
                        newAnswers.Add(k);
                    }
                }
            }
            return newAnswers;
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
