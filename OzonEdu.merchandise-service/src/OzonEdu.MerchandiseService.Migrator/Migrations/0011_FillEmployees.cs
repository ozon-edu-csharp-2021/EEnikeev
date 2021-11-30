using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(11)]
    public class FillEmployees : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO employees 
                (firstname, lastname, hiring_date, email) 
                VALUES 
                ('Ivan', 'Ivanov', '2021-12-17', 'IvanIvanov@ozon.ru'),
                ('Petr', 'Petrov', '2020-11-17', 'PetrPetrov@ozon.ru'),
                ('Roman', 'Romanov', '2019-10-17', 'RomanRomanov@ozon.ru'),
                ('Mikhail', 'Mikhailov', '2018-09-17', 'MikhailMikhailov@ozon.ru'),
                ('Konstantin', 'Konstantinov', '2017-09-17', 'KonstantinKonstantinov@ozon.ru')
                ON CONFLICT DO NOTHING");
            
        }
    }
}