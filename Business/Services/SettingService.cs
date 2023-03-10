using AutoMapper;
using Business.Interfaces;
using Contracts.Dtos.SettingDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class SettingService : ISettingService
    {
        private readonly IBaseRepository<Setting> _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(IBaseRepository<Setting> settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper=mapper;
        }

        public async Task<SettingDto?> GetAsync()
        {
            var result = await _settingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == 1);
            if (result == null)
                return null;
            return _mapper.Map<SettingDto>(result);
        }

        public async Task<SettingDto?> UpdateAsync(UpdateSettingDto updateRequest)
        {
            var setting = await _settingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == 1);
            if (setting == null)
                return null;
            setting = _mapper.Map(updateRequest, setting);

            if (updateRequest.Image != null && updateRequest.Image.Length > 0)
            {
                using var ms = new MemoryStream();
                updateRequest.Image.CopyTo(ms);
                setting.Logo = ms.ToArray();
            }

            var result = await _settingRepository.Update(setting);

            if (result != null)
                return _mapper.Map<SettingDto>(result);
            else
                return null;
        }
    }
}
