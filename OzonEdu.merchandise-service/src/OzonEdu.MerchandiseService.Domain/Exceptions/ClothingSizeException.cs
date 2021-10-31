using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class ClothingSizeException: Exception
    {
        public ClothingSizeException(string message) : base(message) { }
    }
}