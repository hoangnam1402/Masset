using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.SupplierDtos;
using DataAccess.Enums;

namespace Contracts.Dtos.MaintenanceDtos
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public AssetDto? Asset { get; set; }
        public int? AssetID { get; set; }
        public SupplierDto? Supplier { get; set; }
        public int? SupplierID { get; set; }
        public MaintenanceTypeEnums Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }

    }
}
