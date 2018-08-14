namespace CRUD_Angular_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentDb_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
