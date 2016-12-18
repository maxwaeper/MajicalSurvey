using MajicalSurvey.Data.Entities;
using MajicalSurvey.Data.IRepositories;
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
        ISurveyRepository survey;

        public MethodsForStatistics()
        {
            user = new UsersRepository();
            answer = new AnswerRepository();
            question = new QuestionRepository();
            survey = new SurveyRepository();
            context = new Context();
        }

        public List<Answers> GetUsersAnswersById(int id)
        {
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

        public List<Users> GetUserssByAnswersId(int id) 
        {
            List<Users> newUsers = new List<Users>();
            foreach (var item in context.Answers.Include(x => x.User))
            {
                if (item.Id == id)
                {
                    foreach (var k in item.User)
                    {
                        newUsers.Add(k);
                    }
                }
            }
            return newUsers;
        }


        public List<Users> ListForProportion(int questionID)
        {
            List<Users> usersList = new List<Users>();
            List<Users> u = new List<Users>();
            List<Answers> a = answer.GetAllAnswers().Where(x => x.Question.Id == questionID).ToList();
            foreach (var ans in a)
                {
                    u = GetUserssByAnswersId(ans.Id);
                foreach (var item in u)
                {
                    usersList.Add(item);
                }
                   
               }
            return usersList;
        }
     

        public List<Users> UsersOfSurvey(string SurveyName)
        {
          List<Questions> l = question.GetAllQuestions(SurveyName);
           List<Users> usersList = new List<Users>();
          foreach (var question in l)
           {
              List<Answers> a = answer.GetAllAnswers().Where(x=>x.Question.Id == question.Id).ToList();
                foreach (var answer in a)
                {
                    List<Users> u = GetUserssByAnswersId(answer.Id);
                    foreach (var item in u)
                    {
                        usersList.Add(item);
                    }
                }
            }
            return usersList;
        }

    }
}
