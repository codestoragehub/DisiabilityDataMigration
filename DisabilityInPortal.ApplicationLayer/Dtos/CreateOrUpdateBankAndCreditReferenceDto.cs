using System;
using DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.BankAndCreditReferences.Commands.CreateBankAndCreditReferences;

public class CreateOrUpdateBankAndCreditReferenceDto : AddressDto
{
    public int? BankAndCreditReferenceId { get; set; }
    public string InstitutionName { get; set; }
    public BankAccountType TypeOfAccount { get; set; }
    public string Signatories { get; set; }
    public decimal CreditLine { get; set; }
    public DateTimeOffset LoanDate { get; set; }
    public decimal LoanAmount { get; set; }
    public int? DocumentId { get; set; }
    public new int ApplicationId { get; set; }
    
    public bool HasOutstandingLoans { get; set; }
    public int? LoanAgreementDocumentId { get; set; }
}