namespace OzonEdu.MerchandiseService.Infrastructure.KafkaContracts
{
    public class PayloadContract
    {
        public int MerchType { get; }

        public PayloadContract(int merchType)
        {
            MerchType = merchType;
        }
    }
}