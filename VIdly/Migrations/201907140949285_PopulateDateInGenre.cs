namespace VIdly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDateInGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Drama')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Patriotic')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (6, 'Horror')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (7, 'Sci-fi')");
        }
        
        public override void Down()
        {
        }
    }
}
