using System;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById;
using DisabilityInPortal.ApplicationLayer.Features.WorkflowHistory;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.ApplicationDecisions.Dtos;

public class ApplicationDecisionDto
{
    public int ApplicationDecisionId { get; set; }
    public CertificationStatus CertificationStatus { get; set; }
    public DateTimeOffset? RecertificationDate { get; set; }
    public int ApplicationId { get; set; }
    public string ApplicationReference { get; set; }

    public WorkflowHistoryEventsDto WorkflowHistoryEvents { get; set; }
    public ApplicationDto Application { get; set; }
}