using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued
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