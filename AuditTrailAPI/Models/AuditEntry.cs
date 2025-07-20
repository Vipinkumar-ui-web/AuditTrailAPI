using System;
using System.Collections.Generic;

namespace AuditTrailAPI.Models
{
    public class AuditEntry
    {
            public int Id { get; set; }
            public string EntityName { get; set; }
            public AuditAction ActionType { get; set; }
            public string UserId { get; set; }
            public DateTime Timestamp { get; set; }
            public Dictionary<string, (string? OldValue, string? NewValue)> Changes { get; set; } = new();
       
    }
}
