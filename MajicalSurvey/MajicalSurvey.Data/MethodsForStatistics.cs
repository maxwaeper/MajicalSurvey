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
            //по айди юзера список его ответов
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
           // по айди варианта ответа список ответивших 
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
            //по айди вопроса возвращает список ответивших
        {
            List<Users> usersList = new List<Users>();
            List<Answers> a = answer.GetAllAnswers(questionID);
            foreach (var answer in a)
                {
                    List<Users> u = GetUserssByAnswersId(answer.Id);
                    foreach (var item in u)
                    {
                        usersList.Add(item);
                    }
              
               }
            return usersList;
        }
     

        public List<Users> UsersOfSurvey(string SurveyName)
            //по названию опросника возвращает список ответивших
        {
          List<Questions> l = question.GetAllQuestions(SurveyName);
           List<Users> usersList = new List<Users>();
          foreach (var question in l)
           {
              List<Answers> a = answer.GetAllAnswers(question.Id);
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
