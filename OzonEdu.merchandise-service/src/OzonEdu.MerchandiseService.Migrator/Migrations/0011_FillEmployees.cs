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
                (id, firstname, lastname, hiring_date, email) 
                VALUES 
                (1, 'Ivan', 'Ivanov', '2021-12-17 01:10:54.000000', 'IvanIvanov@ozon.ru'),
                (2, 'Petr', 'Petrov', '2020-11-17 01:10:54.000000', 'PetrPetrov@ozon.ru'),
                (3, 'Roman', 'Romanov', '2019-10-17 01:10:54.000000', 'RomanRomanov@ozon.ru'),
                (4, 'Mikhail', 'Mikhailov', '2018-09-17 01:10:54.000000', 'MikhailMikhailov@ozon.ru'),
                (5, 'Konstantin', 'Konstantinov', '2017-09-17 01:10:54.000000', 'KonstantinKonstantinov@ozon.ru')
                ON CONFLICT DO NOTHING");
            
        }
    }
}