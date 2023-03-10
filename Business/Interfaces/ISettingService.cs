using Contracts.Dtos.SettingDtos;

namespace Business.Interfaces
{
    public interface ISettingService
    {
        Task<SettingDto?> GetAsync();
        Task<SettingDto?> UpdateAsync(UpdateSettingDto updateRequest);
    }
}
