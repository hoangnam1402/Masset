using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.MaintenanceDtos
{
    public class MaintenanceCreateDto
    {
        public int AssetID { get; set; }
        public int? SupplierID { get; set; }
        [EnumDataType(typeof(MaintenanceTypeEnums))]
        public MaintenanceTypeEnums Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
