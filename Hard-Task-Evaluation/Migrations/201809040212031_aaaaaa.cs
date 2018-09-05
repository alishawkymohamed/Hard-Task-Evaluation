namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaa : DbMigration
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
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalInfoes", new[] { "UserId" });
            DropTable("dbo.MedicalInfoes");
        }
    }
}
