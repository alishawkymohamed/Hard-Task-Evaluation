namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaa : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "PhoneNumber" });
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "PhoneNumber", unique: true);
        }
    }
}
