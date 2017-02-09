namespace Medipol.Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusUpdatedToTakenExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TakenExams", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TakenExams", "Status");
        }
    }
}
