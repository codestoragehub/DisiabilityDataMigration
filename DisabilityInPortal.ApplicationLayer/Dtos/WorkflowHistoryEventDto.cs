using DisabilityInPortal.Domain.Enums;
using System;

namespace DisabilityInPortal.ApplicationLayer.Features.WorkflowHistory
{
    public class WorkflowHistoryEventDto
    {
        public int WorkflowHistoryEventId { get; set; }

        public ApplicationStatus OldApplicationStatus { get; set; }
        public ApplicationStatus NewApplicationStatus { get; set; }
        public DateTime ApplicationStatusChangeDate { get; set; }

        public string ApplicationUserId { get; set; }
        public string ApplicationUserFullName { get; set; }

        public int ApplicationId { get; set; }
        public ApplicationWorkflowAction ApplicationWorkflowAction { get; set; }
    }
}
