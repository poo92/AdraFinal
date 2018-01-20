namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountBalances",
                c => new
                    {
                        year = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        rnd = c.Double(nullable: false),
                        canteen = c.Double(nullable: false),
                        ceocar = c.Double(nullable: false),
                        marketing = c.Double(nullable: false),
                        parking = c.Double(nullable: false),
                        uid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.year, t.month });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountBalances");
        }
    }
}
