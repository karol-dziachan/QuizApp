using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Domain.Common;

namespace QuizApp.Domain.Entity
{
    public class Question : BaseEntity
    {
        public string Content { get; set; }
        public int TypeId { get; set; }
        public List<String> Answers;
        public int CorrectAnswerId;

        public Question()
        {

        }

        public Question(int id, string content, int typeId, List<String> answers, int correctAnswerId)
        {
            Id = id;
            Content = content;
            TypeId = typeId;
            Answers = answers;
            CorrectAnswerId = correctAnswerId;
        }

        public string ToString()
        {
            string str = "";

            str = $"Id = {Id}, Content = {Content}, TypeId = {TypeId}, CorrectAnswerId={CorrectAnswerId}";
            str += "\n";
            for (int i = 0; i < Answers.Count(); i++)
            {
                str += $"{i+1}. {Answers[i]} \n";
            }
            return str; 
        }
    }
}
