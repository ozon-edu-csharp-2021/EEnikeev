namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts
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