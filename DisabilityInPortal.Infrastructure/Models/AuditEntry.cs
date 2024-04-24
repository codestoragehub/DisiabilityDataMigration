using System;
using System.Collections.Generic;
using System.Linq;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace DisabilityInPortal.Infrastructure.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
        }

        public EntityEntry Entry { get; set; }

        public string UserId { get; set; }

        public string TableName { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new();

        public Dictionary<string, object> OldValues { get; } = new();

        public Dictionary<string, object> NewValues { get; } = new();

        public List<PropertyEntry> TempporaryProperties { get; } = new();

        public AuditType AuditType { get; set; }

        public List<string> ChangedColumns { get; } = new();

        public bool HasTemporaryProperties => TempporaryProperties.Any();

        public Audit ToAudit()
        {
            var audit = new Audit();
            audit.UserId = UserId;
            audit.Type = AuditType.ToString();
            audit.TableName = TableName;
            audit.DateTimeOffset = DateTimeOffset.UtcNow;
            audit.PrimaryKey = JsonConvert.SerializeObject(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            return audit;
        }
    }
}