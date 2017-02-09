namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamUp : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnswerModels", newName: "Answers");
            RenameTable(name: "dbo.QuestionModels", newName: "Questions");
            RenameTable(name: "dbo.ExamModels", newName: "ExamObjs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ExamObjs", newName: "ExamModels");
            RenameTable(name: "dbo.Questions", newName: "QuestionModels");
            RenameTable(name: "dbo.Answers", newName: "AnswerModels");
        }
    }
}
