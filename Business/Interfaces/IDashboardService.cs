using Contracts.Dtos;

namespace Business.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto?> GetDashboard();

    }
}
