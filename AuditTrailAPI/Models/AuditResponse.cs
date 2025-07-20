namespace AuditTrailAPI.Models
{
    public class AuditResponse
    {
        public string EntityName { get; set; }
        public AuditAction ActionType { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, (string? OldValue, string? NewValue)> ChangedColumns { get; set; } = new();
    }
}
