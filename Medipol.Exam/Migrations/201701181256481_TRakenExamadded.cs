namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TRakenExamadded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TakenExamAnswers", "TakenExamId");
            AddForeignKey("dbo.TakenExamAnswers", "TakenExamId", "dbo.TakenExams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TakenExamAnswers", "TakenExamId", "dbo.TakenExams");
            DropIndex("dbo.TakenExamAnswers", new[] { "TakenExamId" });
        }
    }
}
