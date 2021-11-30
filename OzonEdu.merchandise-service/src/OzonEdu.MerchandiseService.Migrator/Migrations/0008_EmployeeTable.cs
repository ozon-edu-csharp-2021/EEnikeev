using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class EmployeeTable : Migration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE employees(
                            id BIGSERIAL PRIMARY KEY,
                            firstname VARCHAR(30) NOT NULL,
                            lastname VARCHAR(30) NOT NULL,
                            hiring_date DATE NOT NULL,
                            email VARCHAR(30) UNIQUE NOT NULL                            
                        );");
            
            // Create.Table("employees")
            //     .WithColumn("id").AsInt64().Identity().PrimaryKey()
            //     .WithColumn("firstname").AsString().NotNullable()
            //     .WithColumn("lastname").AsString().NotNullable()
            //     .WithColumn("hiring_date").AsDateTime().NotNullable()
            //     .WithColumn("email").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("employees");
        }
    }
}