using DataAccess.Enums;

namespace Contracts.Dtos.MaintenanceDtos
{
    public class MaintenanceCreateAndUpdateDto
    {
        public int? AssetID { get; set; }
        public int? SupplierID { get; set; }
        public MaintenanceTypeEnums? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
