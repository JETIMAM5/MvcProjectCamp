namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 150));
            AddColumn("dbo.Writers", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            DropColumn("dbo.Writers", "MyProperty");
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
