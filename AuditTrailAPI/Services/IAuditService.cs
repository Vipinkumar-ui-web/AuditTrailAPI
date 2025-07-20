using AuditTrailAPI.Models;

namespace AuditTrailAPI.Services
{
    public interface IAuditService
    {
        Task<AuditResponse> TrackChangesAsync(AuditRequest request);
    }
}
