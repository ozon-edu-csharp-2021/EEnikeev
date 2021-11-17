using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(12)]
    public class FillMerchItems : ForwardOnlyMigration 
    {
        public override void Up()
        {
            // заполняем все типы мерчей
            Execute.Sql(@"
                INSERT INTO merch_items
                (id, sku_id, item_type_id)
                VALUES
                
                (1,1,1),
                (2,2,1),
                (3,3,1),
                (4,4,1),
                (5,5,1),
                (6,6,1),
                       
                ( 7, 7,2),
                ( 8, 8,2),
                ( 9, 9,2),
                (10,10,2),
                (11,11,2),
                (12,12,2),
                
                (13,13,3),
                
                (14,14,4),
                
                (15,15,5),
                
                (16,16,6),
                (17,17,6),
                (18,18,6),
                (19,19,6),
                (20,20,6),
                (21,21,6)
                
                ON CONFLICT DO NOTHING");
            
        }
    }
}