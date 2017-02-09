using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medipol.Exam.Models
{
    public class ExamObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Boolean Active { get; set; }
        public List<Question> Questions { get; set; }
        
    }
}