using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medipol.Exam.Models
{
    public class TakenExamAnswer
    {
        public int Id { get; set; }
        public int TakenExamId { get; set; }
        public TakenExam TakenExam { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}