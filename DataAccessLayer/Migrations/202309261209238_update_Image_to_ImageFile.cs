namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Image_to_ImageFile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Images", newName: "ImageFiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ImageFiles", newName: "Images");
        }
    }
}
