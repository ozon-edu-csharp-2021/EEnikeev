using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Factory
{
    public class EmployeeFactory
    {
        private static int _id = 1;

        static List<string> _names = new List<string>()
        {
            "Иван", "Петр", "Кирилл", "Михаил", "Федор", "Егор", "Макар","Борис"
        };

        static Random rand = new Random();
        
        public static Employee CreateEmployee()
        {
            string firstName = _names[rand.Next(_names.Count)];
            string lastName = _names[rand.Next(_names.Count)]+"ов";

            return new Employee(_id++,
                new EmployeeName(firstName),
                new EmployeeName(lastName),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail(firstName + lastName + "@ozon.ru"),
                //EmployeeClothingSize.M, 
                null,
                new MerchIssued(false),
                null
            );
        }
        
    }
}