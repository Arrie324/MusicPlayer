namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.PlaylistSongs", "PlaylistSongsId", "Id");
            //DropPrimaryKey("dbo.PlaylistSongs");
            //AddColumn("dbo.PlaylistSongs", "name", );
            //DropColumn("dbo.PlaylistSongs", "PlaylistSongsId");
            //AddColumn("dbo.PlaylistSongs", "Id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.PlaylistSongs", "Id");
            //DropColumn("dbo.PlaylistSongs", "name");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaylistSongs", "PlaylistSongsId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.PlaylistSongs");
            DropColumn("dbo.PlaylistSongs", "Id");
            AddPrimaryKey("dbo.PlaylistSongs", "PlaylistSongsId");
        }
    }
}
