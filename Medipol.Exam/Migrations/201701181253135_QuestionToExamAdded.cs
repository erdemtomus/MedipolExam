namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionToExamAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Questions", "ExamId");
            AddForeignKey("dbo.Questions", "ExamId", "dbo.ExamObjs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ExamId", "dbo.ExamObjs");
            DropIndex("dbo.Questions", new[] { "ExamId" });
        }
    }
}
