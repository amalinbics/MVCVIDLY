namespace Asp.Net_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Adventure')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'Crime')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (5,'Drama')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (6,'Fantasy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (7,'Historical')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (8,'Historical Fiction')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (9,'Horror')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (10,'Magical Realism')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (11,'Mystery')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (12,'Paranoid Fiction')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (13,'Philosophical')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (14,'Political')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (15,'Romance')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (16,'Saga')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (17,'Satire')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (18,'Science Fiction')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (19,'Social')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (20,'Speculative')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (21,'Thriller')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (22,'Urban')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (23,'Western')");
        }
        
        public override void Down()
        {
        }
    }
}
