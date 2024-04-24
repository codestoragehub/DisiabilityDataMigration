using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("WorkflowHistoryEvents")]
    public class WorkflowHistoryEvent
    {
        public int WorkflowHistoryEventId { get; set; }

        public ApplicationStatus OldApplicationStatus { get; set; }
        public ApplicationStatus NewApplicationStatus { get; set; }
        public DateTime ApplicationStatusChangeDate { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ApplicationWorkflowAction ApplicationWorkflowAction { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [NotMapped]
        public string ApplicationUserFullName => ApplicationUser != null
            ? $"{ApplicationUser.FirstName} {ApplicationUser.LastName}"
            : null;
    }
}
