using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos.MaintenanceDtos
{
    public class MaintenanceResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public string? Asset { get; set; }
        public string? Supplier { get; set; }
        public MaintenanceTypeEnums Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
