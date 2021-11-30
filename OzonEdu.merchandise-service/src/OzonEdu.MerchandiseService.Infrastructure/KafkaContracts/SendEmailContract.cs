namespace OzonEdu.MerchandiseService.Infrastructure.KafkaContracts
{
    public class SendEmailContract
    {
        public string EmployeeEmail { get; }
        
        public string EmployeeName { get; }
        
        public int EventType { get; }
        
        public PayloadContract Payload { get; }
        

        public SendEmailContract(string employeeEmail, string employeeName, int eventType, PayloadContract payload)
        {
            EmployeeEmail = employeeEmail;
            EmployeeName = employeeName;
            EventType = eventType;
            Payload = payload;
        }
    }
}