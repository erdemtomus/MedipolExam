using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medipol.Exam.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Description { get; set; }
        public Boolean TrueAnswer { get; set; }
    }
}