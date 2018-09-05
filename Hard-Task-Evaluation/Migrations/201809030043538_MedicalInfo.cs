namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicalInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        GoalOfDiet = c.String(),
                        ExerciseTime = c.String(),
                        LevelOfExercise = c.String(),
                        DailyFood = c.String(),
                        Vitamins = c.String(),
                        ProblemHistory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "MedicalInfoId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MedicalInfoId");
            AddForeignKey("dbo.AspNetUsers", "MedicalInfoId", "dbo.MedicalInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "MedicalInfoId", "dbo.MedicalInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "MedicalInfoId" });
            DropColumn("dbo.AspNetUsers", "MedicalInfoId");
            DropTable("dbo.MedicalInfoes");
        }
    }
}
