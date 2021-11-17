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
                       
                (7,7,2,1),
                (8,8,2,2),
                (9,9,2,3),
                (10,10,2,4),
                (11,11,2,5),
                (12,12,2,6),
                
                (13,13,3,1),
                (14,14,3,2),
                (15,15,3,3),
                (16,16,3,4),
                (17,17,3,5),
                (18,18,3,6),
                
                (19,19,4,1),
                (20,20,4,2),
                (21,21,4,3),
                (22,22,4,4),
                (23,23,4,5),
                (24,24,4,6),
                
                (25,25,5,1),
                (26,26,5,2),
                (27,27,5,3),
                (28,28,5,4),
                (29,29,5,5),
                (30,30,5,6),
                
                (31,31,6,1),
                (32,32,6,2),
                (33,33,6,3),
                (34,34,6,4),
                (35,35,6,5),
                (36,36,6,6)
                ON CONFLICT DO NOTHING");
        }
    }
}