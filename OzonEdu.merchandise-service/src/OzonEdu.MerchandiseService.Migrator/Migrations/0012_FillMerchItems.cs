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
                (sku_id, item_type_id)
                VALUES
                
                (1,1),
                (2,1),
                (3,1),
                (4,1),
                (5,1),
                (6,1),
                       
                (7,2),
                (8,2),
                (9,2),
                (10,2),
                (11,2),
                (12,2),
                
                (13,3),
                
                (14,4),
                
                (15,5),
                
                (16,6),
                (17,6),
                (18,6),
                (19,6),
                (20,6),
                (21,6)
                
                ON CONFLICT DO NOTHING");
            
        }
    }
}