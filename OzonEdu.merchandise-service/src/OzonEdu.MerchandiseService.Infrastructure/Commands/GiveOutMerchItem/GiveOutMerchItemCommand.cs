using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem
{
    public class GiveOutMerchItemCommand : IRequest
    {
        public long Sku { get; }
        
        public int Quantity { get; }
    }
}