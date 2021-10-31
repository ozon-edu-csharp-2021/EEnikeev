using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem
{
    /// <summary> Проверить, выдан ли мерч </summary>
    public class GetMerchIsIssuedCommand: IRequest<Unit>
    {
        public int Id { get; }
        
        public GetMerchIsIssuedCommand(int id)
        {
            Id = id;
        }
    }
}