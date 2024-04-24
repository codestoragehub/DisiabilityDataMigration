using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.WorkflowHistory
{
    public class WorkflowHistoryEventsDto
    { 
        public int ApplicationId { get; set; }

        public List<WorkflowHistoryEventDto> WorkflowHistoryEvents { get; set; }
    }
}
