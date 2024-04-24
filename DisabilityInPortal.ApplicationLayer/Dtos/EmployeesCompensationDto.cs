namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

public class EmployeesCompensationDto
{
    public string NumberOfFullAndPartTimeEmployees { get; set; }
    public bool IsHiringAndFiring { get; set; }
    public string HiringProcedures { get; set; }
    public string FiringProcedures { get; set; }
    public bool IsHighestPaidPerson { get; set; }
    public string IfNoWhyNotAndWhoIs { get; set; }
    public string SiteVisitorsComment { get; set; }
}