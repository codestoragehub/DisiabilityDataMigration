﻿using DisabilityInPortal.ApplicationLayer.Features.Countries.Queries.GetCountryById;
using DisabilityInPortal.ApplicationLayer.Features.States.Queries.GetStateById;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;

public class AddressDto
{
    public int AddressId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public AddressType AddressType { get; set; }
    public string Address1 { get; set; }
    public string City { get; set; }
    public int? StateId { get; set; }
    public StateDto State { get; set; }
    public string ZipCode { get; set; }
    public string ZipCodePlus4 { get; set; }
    public int? CountryId { get; set; }
    public CountryDto Country { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CellPhone { get; set; }
    public string Fax { get; set; }
    public int ApplicationId { get; set; }
    public int? CompanyId { get; set; }
    public string UserId { get; set; }
    public string Ext { get; set; }
    public bool HasMailingAddressSameAsHQ { get; set; }
    public bool HasPrimaryOwnerContactSameAsHQ { get; set; }
    public bool HasCompanyContactSameAsPrimaryOwnerContact { get; set; }
}