using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class ItemTypesTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE item_types(
                            id SERIAL PRIMARY KEY,
                            name VARCHAR(30) NOT NULL
                        );");
            
            // Create
            //     .Table("item_types")
            //     .WithColumn("id").AsInt32().PrimaryKey()
            //     .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_types");
        }
        
    }
}