namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AnswerModels", "QuestionId");
            AddForeignKey("dbo.AnswerModels", "QuestionId", "dbo.QuestionModels", "Id", cascadeDelete: true);
            DropColumn("dbo.QuestionModels", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionModels", "Answer", c => c.String());
            DropForeignKey("dbo.AnswerModels", "QuestionId", "dbo.QuestionModels");
            DropIndex("dbo.AnswerModels", new[] { "QuestionId" });
        }
    }
}
