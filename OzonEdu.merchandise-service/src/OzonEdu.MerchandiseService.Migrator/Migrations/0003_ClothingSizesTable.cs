using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(3)]
    public class ClothingSizesTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE clothing_sizes(
                            id SERIAL PRIMARY KEY,
                            name VARCHAR(30) NOT NULL
                        );");
            
            // Create
            //     .Table("clothing_sizes")
            //     .WithColumn("id").AsInt32().PrimaryKey()
            //     .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("clothing_sizes");
        }
    }
}