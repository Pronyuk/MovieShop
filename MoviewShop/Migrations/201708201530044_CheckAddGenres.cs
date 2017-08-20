namespace MoviewShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckAddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Action')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Drama')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Detective')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Triller')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
