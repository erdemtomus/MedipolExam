using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Medipol.Exam.Models
{
    public class TakenExam
    {
        public int Id { get; set; }
        public DateTime TakenDate { get; set; }
        public string Username { get; set; }
        public int ExamId { get; set; }
        public List<TakenExamAnswer> TakenExamAnswers { get; set; }
        public int Status { get; set; }

        public int Score { get; set; }
    }
}