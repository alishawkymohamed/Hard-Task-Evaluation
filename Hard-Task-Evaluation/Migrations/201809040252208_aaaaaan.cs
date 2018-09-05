namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalInfoes", new[] { "UserId" });
            AddColumn("dbo.AspNetUsers", "MedicalInfoId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MedicalInfoId");
            AddForeignKey("dbo.AspNetUsers", "MedicalInfoId", "dbo.MedicalInfoes", "Id");
            DropColumn("dbo.MedicalInfoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalInfoes", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "MedicalInfoId", "dbo.MedicalInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "MedicalInfoId" });
            DropColumn("dbo.AspNetUsers", "MedicalInfoId");
            CreateIndex("dbo.MedicalInfoes", "UserId");
            AddForeignKey("dbo.MedicalInfoes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
