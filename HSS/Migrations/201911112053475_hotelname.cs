namespace HSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "HotelName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "HotelName");
        }
    }
}
