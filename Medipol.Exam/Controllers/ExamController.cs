using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medipol.Exam.Models;
using Medipol.Exam.ViewModels;

namespace Medipol.Exam.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private ApplicationDbContext _db;

        public ExamController()
        {
            _db = new ApplicationDbContext();
        }


        

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: ExamObj
        public ActionResult Index(int? id)
        {
            //if (!User.Identity.IsAuthenticated)st
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{

            string username = User.Identity.Name;
            TakenExam exam = _db.TakenExams.FirstOrDefault(t => t.ExamId == id && t.Username == username);
            if (exam != null && exam.Status == 1)
            {
                TempData["message"] = "Sınavı Daha Önce Tamamlamış Gözüküyorsunuz";
                return RedirectToAction("Index", "Home");
            }

            Random rnd = new Random();
            try
            {
                ExamQuestionsVM eq = new ExamQuestionsVM
                {
                    CurrentExam = _db.Exams.Include(t => t.Questions.Select(k => k.Answers)).Single(t => t.Id == id),
                    ExamTakerId = User.Identity.Name,
                    ExamId = id.Value,
                    TakenExam = _db.TakenExams.Include(t=>t.TakenExamAnswers).FirstOrDefault(t=>t.ExamId==id.Value && t.Username==username)
                };
                return View(eq);
            }
            catch (Exception rc)
            {
                return RedirectToAction("Index");
            }
                
            //}
            
        }


        public ActionResult Sonuclar()
        {
            if (User.Identity.Name == "erdemtomus@gmail.com")
            {
                var res = _db.TakenExams.ToList();
                return View(res);
            }
            else
                return RedirectToAction("Index","Home");
        }

        [Authorize]
        //public ActionResult Finish(int id)
        //{

        //    int dogruSayisi = CalculateResult(id, User.Identity.Name);
        //    try
        //    {
        //        string username = User.Identity.Name;
        //        TakenExam te = _db.TakenExams.FirstOrDefault(t => t.ExamId == id && t.Username == username);
        //        te.Status = 1;
        //        te.Score = dogruSayisi;
        //        _db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //    }

            
        //    return View("Result", dogruSayisi);

        //}

        [HttpPost]
        public ActionResult SaveExam(ExamQuestionsVM myExam,string saveExam,string finishExam)
        {
            var t = TakenExam(myExam);
            if(!String.IsNullOrEmpty(finishExam))
            {
                int dogruSayisi = CalculateResult(myExam.ExamId, User.Identity.Name);
                try
                {
                    string username = User.Identity.Name;
                    TakenExam te = _db.TakenExams.FirstOrDefault(b => b.ExamId == myExam.ExamId && b.Username == username);
                    te.Status = 1;
                    te.Score = dogruSayisi;
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                }


                return View("Result", dogruSayisi);
            }

            TempData["message"] = "Başarıyla Kaydedildi.";
            return RedirectToAction("Index", new {id = myExam.ExamId});
        }

        private TakenExam TakenExam(ExamQuestionsVM myExam)
        {
            TakenExam t = _db.TakenExams.FirstOrDefault(z => z.Username == User.Identity.Name);

            if (t != null)
            {
                foreach (Question q in myExam.CurrentExam.Questions)
                {
                    var givenAnswer = _db.TakenExamAnswers.FirstOrDefault(h => h.QuestionId == q.Id && h.TakenExamId== t.Id);
                    if (givenAnswer != null)
                    {
                        givenAnswer.AnswerId = q.SelectedQAnswerId.HasValue ? q.SelectedQAnswerId.Value : 0;
                        _db.SaveChanges();
                    }
                    else
                    {
                        TakenExamAnswer ta = new TakenExamAnswer
                        {
                            AnswerId = q.SelectedQAnswerId.HasValue ? q.SelectedQAnswerId.Value : 0,
                            QuestionId = q.Id,
                            TakenExamId = t.Id
                        };
                        _db.TakenExamAnswers.Add(ta);
                        _db.SaveChanges();
                    }
                }
            }
            else
            {
                t = new TakenExam();
                t.ExamId = myExam.ExamId;
                t.TakenDate = DateTime.Now;
                t.Username = User.Identity.Name;
                _db.TakenExams.Add(t);
                _db.SaveChanges();

                foreach (Question q in myExam.CurrentExam.Questions)
                {
                    TakenExamAnswer ta = new TakenExamAnswer
                    {
                        AnswerId = q.SelectedQAnswerId.HasValue ? q.SelectedQAnswerId.Value : 0,
                        QuestionId = q.Id,
                        TakenExamId = t.Id
                    };

                    _db.TakenExamAnswers.Add(ta);
                }
                _db.SaveChanges();
            }
            return t;
        }

        private int res = 0;
        private int CalculateResult(int tId,string username)
        {
            res = 0;
            var answ = _db.TakenExamAnswers.Where(t=>t.TakenExam.ExamId==tId && t.TakenExam.Username==username).ToList();
            foreach (TakenExamAnswer userAnswer in answ)
            {
                int questionID = userAnswer.QuestionId;
                int answerID = userAnswer.AnswerId;

                if(answerID!=0)
                {
                    var givenAnswer = _db.Answers.First(t => t.QuestionId == questionID && t.Id == answerID);
                    if (givenAnswer != null && givenAnswer.TrueAnswer)
                        res++;
                }
            }
            return res;
        }
    }
}