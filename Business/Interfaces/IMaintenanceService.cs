﻿using Contracts;
using Contracts.Dtos.MaintenanceDtos;

namespace Business.Interfaces
{
    public interface IMaintenanceService
    {
        Task<PagedResponseModel<MaintenanceDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<MaintenanceDto>> GetOfAssetAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, int id);
        Task<MaintenanceDto?> CreateAsync(MaintenanceCreateDto createRequest);
        Task<MaintenanceDto?> UpdateAsync(int id, MaintenanceUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsDelete(int id);

    }
}
