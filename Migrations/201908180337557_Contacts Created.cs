namespace mvcdemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactsCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Phone = c.String(maxLength: 50),
                        Profile = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
