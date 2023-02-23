using DataAccess.Enums;

namespace Contracts.Dtos.MaintenanceDtos
{
    public class MaintenanceUpdateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
