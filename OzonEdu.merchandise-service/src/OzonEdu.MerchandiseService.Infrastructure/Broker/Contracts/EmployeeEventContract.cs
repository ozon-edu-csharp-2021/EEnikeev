namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts
{
    public class EmployeeEventContract
    {
        public string EmployeeEmail { get; }
        
        public string EmployeeName { get; }
        
        public int EventType { get; }
        
        public PayloadContract Payload { get; }
        

        public EmployeeEventContract(string employeeEmail, string employeeName, int eventType, PayloadContract payload)
        {
            EmployeeEmail = employeeEmail;
            EmployeeName = employeeName;
            EventType = eventType;
            Payload = payload;
        }
    }
}