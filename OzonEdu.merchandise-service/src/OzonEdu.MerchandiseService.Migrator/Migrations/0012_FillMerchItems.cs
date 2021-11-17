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
                (id, sku_id, item_type_id, clothing_size_id)
                VALUES
                
                (1,1,1,1),
                (2,2,1,2),
                (3,3,1,3),
                (4,4,1,4),
                (5,5,1,5),
                (6,6,1,6),
                       
                ( 7, 7,2,1),
                ( 8, 8,2,2),
                ( 9, 9,2,3),
                (10,10,2,4),
                (11,11,2,5),
                (12,12,2,6),
                
                (13,13,3,NULL),
                
                (14,14,4,NULL),
                
                (15,15,5,NULL),
                
                (16,16,6,1),
                (17,17,6,2),
                (18,18,6,3),
                (19,19,6,4),
                (20,20,6,5),
                (21,21,6,6)
                
                ON CONFLICT DO NOTHING");
            
        }
    }
}