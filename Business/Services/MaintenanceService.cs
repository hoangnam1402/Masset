using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.EnumDtos;
using Contracts.Dtos.MaintenanceDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IBaseRepository<Maintenance> _maintenanceRepository;
        private readonly IMapper _mapper;

        public MaintenanceService(IBaseRepository<Maintenance> maintenanceRepository, IMapper mapper)
        {
            _maintenanceRepository = maintenanceRepository;
            _mapper = mapper;
        }

        public async Task<MaintenanceDto?> CreateAsync(MaintenanceCreateDto createRequest)
        {
            var maintenance = _mapper.Map<Maintenance>(createRequest);

            maintenance.IsDeleted = false;

            var result = await _maintenanceRepository.Add(maintenance);
            if (result != null)
            {
                return _mapper.Map<MaintenanceDto>(maintenance);
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var maintenance = await _maintenanceRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (maintenance == null)
                return false;
            maintenance.IsDeleted = true;

            var result = await _maintenanceRepository.Update(maintenance);

            return result!=null;
        }

        public async Task<MaintenanceDto?> GetByIdAsync(int id)
        {
            var result = await _maintenanceRepository.Entities
                .Include(s => s.Supplier)
                .Include(s => s.Asset)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<MaintenanceDto>(result);
            return null;
        }

        public async Task<PagedResponseModel<MaintenanceDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, 
                                                                            CancellationToken cancellationToken)
        {
            var maintenanceQuery = MaintenanceFilter(
                _maintenanceRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await maintenanceQuery
                .AsNoTracking()
                .Include("Asset")
                .Include("Supplier")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<MaintenanceDto>>(result.Items);

            return new PagedResponseModel<MaintenanceDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _maintenanceRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _maintenanceRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<MaintenanceDto?> UpdateAsync(int id, MaintenanceUpdateDto updateRequest)
        {
            var maintenance = await _maintenanceRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (maintenance == null)
                return null;
            maintenance = _mapper.Map(updateRequest, maintenance);
            var result = await _maintenanceRepository.Update(maintenance);

            if (result != null)
                return _mapper.Map<MaintenanceDto>(result);
            else
                return null;
        }

        #region Private Method
        private IQueryable<Maintenance> MaintenanceFilter(
            IQueryable<Maintenance> maintenanceQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                maintenanceQuery = maintenanceQuery.Where(b =>
                    (b.Asset != null && b.Asset.Name != null && b.Asset.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Asset != null && b.Asset.Tag != null && b.Asset.Tag.Contains(baseQueryCriteria.Search)) ||
                    (b.Supplier != null && b.Supplier.Name != null && b.Supplier.Name.Contains(baseQueryCriteria.Search))
                    );
            }

            if (baseQueryCriteria.SortColumn == "type")
            {
                maintenanceQuery = baseQueryCriteria.SortOrder == SortOrderEnumDto.Accsending
                    ? maintenanceQuery.OrderBy(p =>
                    p.Type == MaintenanceTypeEnums.Maintenance ? "Maintenance" :
                    p.Type == MaintenanceTypeEnums.Repair ? "Repair" :
                    p.Type == MaintenanceTypeEnums.Upgrade ? "Upgrade" :
                    p.Type == MaintenanceTypeEnums.Testing ? "Testing" :
                    p.Type == MaintenanceTypeEnums.Calibration ? "Calibration" :
                    p.Type == MaintenanceTypeEnums.SoftwareSupport ? "SoftwareSupport" :
                    p.Type == MaintenanceTypeEnums.HardwareSupport ? "HardwareSupport" :
                    "ZZZ"
                    )
                    : maintenanceQuery.OrderByDescending(p =>
                    p.Type == MaintenanceTypeEnums.Maintenance ? "Maintenance" :
                    p.Type == MaintenanceTypeEnums.Repair ? "Repair" :
                    p.Type == MaintenanceTypeEnums.Upgrade ? "Upgrade" :
                    p.Type == MaintenanceTypeEnums.Testing ? "Testing" :
                    p.Type == MaintenanceTypeEnums.Calibration ? "Calibration" :
                    p.Type == MaintenanceTypeEnums.SoftwareSupport ? "SoftwareSupport" :
                    p.Type == MaintenanceTypeEnums.HardwareSupport ? "HardwareSupport" :
                    "ZZZ");
                baseQueryCriteria.SortColumn = null;
            }

            //not showing deleted asset
            maintenanceQuery = maintenanceQuery.Where(x => x.IsDeleted == false);

            return maintenanceQuery;
        }

        #endregion

    }
}
