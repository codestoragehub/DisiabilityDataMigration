using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("States")]
public class State
{
    public int StateId { get; set; }
    public int CountryId { get; set; }

    [StringLength(256)]
    public string Name { get; set; }

    [StringLength(128)]
    public string Code { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
}