namespace AuditTrailAPI.Models
{
    public class AuditRequest
    {
            public string EntityName { get; set; }
            public AuditAction ActionType { get; set; }
            public string UserId { get; set; }
            public object? BeforeChange { get; set; }
            public object? AfterChange { get; set; }
     
    }
}
