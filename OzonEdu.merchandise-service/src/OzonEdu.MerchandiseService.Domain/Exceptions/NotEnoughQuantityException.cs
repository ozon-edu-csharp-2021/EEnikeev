using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class NotEnoughQuantityException : Exception
    {
        public NotEnoughQuantityException(string message) : base(message) { }
    }
}