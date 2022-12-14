namespace LongURLToShortURLConverter_EH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableUrlInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongUrl = c.String(),
                        ShortUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urls");
        }
    }
}
