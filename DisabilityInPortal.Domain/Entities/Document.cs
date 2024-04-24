using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("Documents")]
public class Document : AuditBaseEntity
{
    public int DocumentId { get; set; }

    public DocumentType Type { get; set; }

    [Required]
    [StringLength(1024)]
    public string FileName { get; set; }

    [Required]
    public int ApplicationId { get; set; }

    public int? CompanyId { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }

    [ForeignKey("ApplicationId")]
    public Application Application { get; set; }

    [ForeignKey("CompanyId")]
    public Company Company { get; set; }
}