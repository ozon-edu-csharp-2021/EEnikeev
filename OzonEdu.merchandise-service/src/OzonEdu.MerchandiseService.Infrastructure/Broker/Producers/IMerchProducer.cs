using OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Producers
{
    public interface IMerchProducer
    {
        public void SendEmail(EmployeeEventContract contract);

    }
}