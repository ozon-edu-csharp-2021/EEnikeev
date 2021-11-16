using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels
{
    public class Employee
    {
        public long Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string Lastname { get; set; }
        
        public DateTime HiringDate { get; set; }
        
        public string Email { get; set; }

    }
}