using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.ComponentDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IBaseRepository<Component> _componentRepository;
        private readonly IMapper _mapper;

        public ComponentService(IBaseRepository<Component> componentRepository, IMapper mapper)
        {
            _componentRepository = componentRepository;
            _mapper = mapper;
        }

        public async Task<ComponentDto?> CreateAsync(ComponentCreateDto createRequest)
        {
            var newComponent = _mapper.Map<Component>(createRequest);

            newComponent.CreateDay = DateTime.Now;
            newComponent.UpdateDay = DateTime.Now;
            newComponent.Status = AssetStatusEnums.ReadyToDeploy;
            newComponent.AvailableQuantity = createRequest.Quantity;
            newComponent.IsDeleted = false;

            var result = await _componentRepository.Add(newComponent);
            if (result != null)
            {
                return _mapper.Map<ComponentDto>(newComponent);
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var component = await _componentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (component == null)
                return false;
            component.IsDeleted = true;

            var result = await _componentRepository.Update(component);

            return result!=null;
        }

        public async Task<PagedResponseModel<ComponentDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, 
                                                                        CancellationToken cancellationToken)
        {
            var componentQuery = ComponentFilter(
                _componentRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await componentQuery
                .AsNoTracking()
                .Include("Type")
                .Include("Supplier")
                .Include("Location")
                .Include("Brand")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<ComponentDto>>(result.Items);

            return new PagedResponseModel<ComponentDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<ComponentDto?> GetByIdAsync(int id)
        {
            var result = await _componentRepository.Entities
                .Include(s => s.Supplier)
                .Include(s => s.Type)
                .Include(s => s.Location)
                .Include(s => s.Brand)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<ComponentDto>(result);
            return null;
        }

        public async Task<IList<ComponentDto>> GetAll()
        {
            var result = await _componentRepository.GetAll();
            result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<ComponentDto>>(result);
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _componentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _componentRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _componentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<ComponentDto?> UpdateAsync(int id, ComponentUpdateDto updateRequest)
        {
            var component = await _componentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (component == null)
                return null;
            component = _mapper.Map(updateRequest, component);

            component.UpdateDay = DateTime.Now;

            var result = await _componentRepository.Update(component);

            if (result != null)
                return _mapper.Map<ComponentDto>(result);
            else
                return null;
        }

        #region Private Method
        private IQueryable<Component> ComponentFilter(
            IQueryable<Component> componentQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                componentQuery = componentQuery.Where(b =>
                    (b.Name != null && b.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Type != null && b.Type.Name != null && b.Type.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Brand != null && b.Brand.Name != null && b.Brand.Name.Contains(baseQueryCriteria.Search))
                    );
            }

            //not showing deleted asset
            componentQuery = componentQuery.Where(x => x.IsDeleted == false);

            return componentQuery;
        }

        #endregion
    }
}