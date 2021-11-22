using System;
using System.Dynamic;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels
{
    public class MerchPackOrder
    {
        public long Id { get; set; }

        public long EmployeeId { get; set; }

        public int MerchPackId { get; set; }

        public bool IsGiven { get; set; }

        public DateTime GivingDate { get; set; }
}
}