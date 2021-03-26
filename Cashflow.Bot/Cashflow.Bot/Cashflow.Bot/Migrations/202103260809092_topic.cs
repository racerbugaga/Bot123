namespace Cashflow.Bot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TopicEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TopicEntities");
        }
    }
}
