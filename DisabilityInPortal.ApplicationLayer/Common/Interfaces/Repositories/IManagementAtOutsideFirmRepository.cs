﻿using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementAtOutsideFirmRepository
{
    Task<ManagementAtOutsideFirm> GetManagementAtOutsideFirmByIdAsync(int managementAtOutsideFirmId);
}