using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("TrustDetails")]
    public class TrustDetail
    {
        public int TrustDetailId { get; set; }

        public bool IsBusinessControlledByTrust { get; set; }
        public bool? IsIrrevocable { get; set; }
        public bool IsBenefactor { get; set; }
        public bool IsGrantor { get; set; }
        public bool IsTrustee { get; set; }

        public int? DocumentId { get; set; }
        public Document Document { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
