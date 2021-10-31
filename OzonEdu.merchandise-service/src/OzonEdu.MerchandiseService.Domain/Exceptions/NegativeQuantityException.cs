using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class NegativeQuantityException : Exception
    {
        public NegativeQuantityException(string message) : base(message) { }
    }
}