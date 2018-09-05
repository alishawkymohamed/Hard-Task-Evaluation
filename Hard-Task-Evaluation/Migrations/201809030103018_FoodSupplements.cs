namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodSupplements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food_Supplements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Food_SupplementsType = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Item = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Protien = c.Int(nullable: false),
                        Fat = c.Int(nullable: false),
                        Carb = c.Int(nullable: false),
                        TotalCalories = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food_Supplements", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Food_Supplements", new[] { "UserId" });
            DropTable("dbo.Food_Supplements");
        }
    }
}
