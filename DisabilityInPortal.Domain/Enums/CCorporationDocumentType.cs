using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum CCorporationDocumentType
    {
        [Display(Name = "Form 1120 Schedule G")]
        Form1120ScheduleG = 1,
        [Display(Name = "Certificate of Incorporation")]
        CertificateOfIncorporation = 2,
        [Display(Name = "Articles of Incorporation")]
        ArticlesOfIncorporation = 3,
        [Display(Name = "Minutes of first board meeting establishing current ownership")]
        FirstBoardMeetingEstablishingCurentOwnership = 4,
        [Display(Name = "Minutes from most recent meeting of shareholders")]
        MostRecentShareholdersMeeting = 5,
        [Display(Name = "Minutes from most recent meeting of the Board")]
        MostRecentBoardMeeting = 6,
        [Display(Name = "Corporate bylaws")]
        CorporateByLaws = 7,
        [Display(Name = "Copies of stock certificates (both sides) or proof of stock purchase or equity agreement by owner(s) with a disability and/or currents stock transfer ledger")]
        CopiesOfStockCertificates = 8,        
    }
}
