namespace HSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "ConfrimPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "ConfrimPassword", c => c.String());
        }
    }
}
