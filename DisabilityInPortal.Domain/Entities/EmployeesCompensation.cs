using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("EmployeesCompensations")]
public class EmployeesCompensation
{
    public int EmployeesCompensationId { get; set; }

    [StringLength(1024)]
    public string NumberOfFullAndPartTimeEmployees { get; set; }

    public bool IsHiringAndFiring { get; set; }

    [StringLength(1024)]
    public string HiringProcedures { get; set; }

    [StringLength(1024)]
    public string FiringProcedures { get; set; }

    public bool IsHighestPaidPerson { get; set; }

    [StringLength(1024)]
    public string IfNoWhyNotAndWhoIs { get; set; }

    [StringLength(1024)]
    public string SiteVisitorsComment { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}