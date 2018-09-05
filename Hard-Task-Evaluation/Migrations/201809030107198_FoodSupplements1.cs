namespace Hard_Task_Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodSupplements1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food_Supplements", "Time", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food_Supplements", "Time");
        }
    }
}
