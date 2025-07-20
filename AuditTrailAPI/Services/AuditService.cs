using AuditTrailAPI.Data;
using AuditTrailAPI.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AuditTrailAPI.Services
{
    public class AuditService : IAuditService
    {
        private readonly AuditDbContext _context;

        public AuditService(AuditDbContext context)
        {
            _context = context;
        }
        public async Task<AuditResponse> TrackChangesAsync(AuditRequest request)
        {
            var entry = new AuditEntry
            {
                EntityName = request.EntityName,
                ActionType = request.ActionType,
                UserId = request.UserId,
                Timestamp = DateTime.UtcNow
            };

            if (request.ActionType == AuditAction.Updated)
            {
                var before = JObject.FromObject(request.BeforeChange ?? new());
                var after = JObject.FromObject(request.AfterChange ?? new());

                foreach (var prop in before.Properties())
                {
                    var afterProp = after.Property(prop.Name);
                    if (afterProp != null && !JToken.DeepEquals(prop.Value, afterProp.Value))
                    {
                        entry.Changes[prop.Name] = (prop.Value.ToString(), afterProp.Value.ToString());
                    }
                }
            }
            else if (request.ActionType == AuditAction.Created)
            {
                var after = JObject.FromObject(request.AfterChange ?? new());
                foreach (var prop in after.Properties())
                {
                    entry.Changes[prop.Name] = (null, prop.Value.ToString());
                }
            }
            else if (request.ActionType == AuditAction.Deleted)
            {
                var before = JObject.FromObject(request.BeforeChange ?? new());
                foreach (var prop in before.Properties())
                {
                    entry.Changes[prop.Name] = (prop.Value.ToString(), null);
                }
            }

            _context.AuditEntries.Add(entry);
            await _context.SaveChangesAsync();

            return new AuditResponse
            {
                EntityName = entry.EntityName,
                ActionType = entry.ActionType,
                UserId = entry.UserId,
                Timestamp = entry.Timestamp,
                ChangedColumns = entry.Changes
            };
        }
    }
}
