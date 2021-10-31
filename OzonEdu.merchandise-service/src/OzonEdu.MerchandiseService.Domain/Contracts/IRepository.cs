using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.Contracts
{
    public interface IRepository<T> //where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
