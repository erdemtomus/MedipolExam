using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medipol.Exam.Models;

namespace Medipol.Exam.ViewModels
{
    public class ExamQuestionsVM
    {
        public ExamObj CurrentExam { get; set; }
        public string ExamTakerId { get; set; }
        public int ExamId { get; set; }
        public TakenExam TakenExam { get; set; }

        //public int TakenExamId { get; set; }

    }
}