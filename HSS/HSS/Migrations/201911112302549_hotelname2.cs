namespace HSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelname2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "HotelName", c => c.String());
            DropTable("dbo.Rooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Id_customer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            DropColumn("dbo.Customers", "HotelName");
        }
    }
}
