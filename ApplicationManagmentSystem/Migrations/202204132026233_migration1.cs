namespace ApplicationManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technicians",
                c => new
                    {
                        idTechnician = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        telegramId = c.String(),
                        telegramProtected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idTechnician);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Technicians");
        }
    }
}
