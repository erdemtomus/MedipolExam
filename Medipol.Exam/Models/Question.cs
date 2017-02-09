using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medipol.Exam.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ExamId { get; set; }
        public ExamObj Exam { get; set; }
        public List<Answer> Answers { get; set; }
        
        public int? SelectedQAnswerId { get; set; }
        //public string Answer { get; set; }
    }
}