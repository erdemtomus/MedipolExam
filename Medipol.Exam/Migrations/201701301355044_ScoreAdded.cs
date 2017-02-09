namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TakenExams", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TakenExams", "Score");
        }
    }
}
