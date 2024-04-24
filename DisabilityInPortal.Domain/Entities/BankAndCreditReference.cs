using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("BankAndCreditReferences")]
public class BankAndCreditReference
{
    public int BankAndCreditReferenceId { get; set; }

    [StringLength(250)]
    public string InstitutionName { get; set; }

    public int? AddressId { get; set; }
    public Address Address { get; set; }
    public BankAccountType TypeOfAccount { get; set; }

    [StringLength(200)]
    public string Signatories { get; set; }

    public decimal CreditLine { get; set; }

    public DateTimeOffset LoanDate { get; set; }
    public decimal LoanAmount { get; set; }
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    
    public bool HasOutstandingLoans { get; set; }
    public int? LoanAgreementDocumentId { get; set; }
    public Document LoanAgreementDocument { get; set; }
}