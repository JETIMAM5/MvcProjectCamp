namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_writer_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
