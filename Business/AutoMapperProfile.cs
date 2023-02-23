using Contracts.Dtos;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.ComponentDtos;
using Contracts.Dtos.DepreciationDtos;
using Contracts.Dtos.EmployeeDtos;
using Contracts.Dtos.MaintenanceDtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;

namespace Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            //Employee
            CreateMap<EmployeeDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<LoginDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<EmployeeCreateDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<EmployeeUpdateDto, Employee>(memberList: AutoMapper.MemberList.None);

            //User
            CreateMap<UserDto, User>(memberList: AutoMapper.MemberList.None);
            CreateMap<UserCreateDto, User>(memberList: AutoMapper.MemberList.None);
            CreateMap<UserUpdateDto, User>(memberList: AutoMapper.MemberList.None);
            CreateMap<LoginDto, User>(memberList: AutoMapper.MemberList.None);

            //Asset
            CreateMap<AssetDto, Asset>(memberList: AutoMapper.MemberList.None);
            CreateMap<AssetCreateDto, Asset>(memberList: AutoMapper.MemberList.None);
            CreateMap<AssetUpdateDto, Asset>(memberList: AutoMapper.MemberList.None);

            //Component
            CreateMap<ComponentDto, Component>(memberList: AutoMapper.MemberList.None);
            CreateMap<ComponentCreateDto, Component>(memberList: AutoMapper.MemberList.None);
            CreateMap<ComponentUpdateDto, Component>(memberList: AutoMapper.MemberList.None);

            //Maintenance
            CreateMap<MaintenanceDto, Maintenance>(memberList: AutoMapper.MemberList.None);
            CreateMap<MaintenanceCreateDto, Maintenance>(memberList: AutoMapper.MemberList.None);
            CreateMap<MaintenanceUpdateDto, Maintenance>(memberList: AutoMapper.MemberList.None);

            //Depreciation
            CreateMap<DepreciationDto, Depreciation>(memberList: AutoMapper.MemberList.None);
            CreateMap<DepreciationCreateDto, Depreciation>(memberList: AutoMapper.MemberList.None);
            CreateMap<DepreciationUpdateDto, Depreciation>(memberList: AutoMapper.MemberList.None);
        }

        private void FromDataAccessorLayer()
        {
            //Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, LoginDto>();
            CreateMap<Employee, EmployeeUpdateDto>();
            CreateMap<Employee, EmployeeCreateDto>();

            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<User, LoginDto>();

            //Asset
            CreateMap<Asset, AssetDto>();
            CreateMap<Asset, AssetCreateDto>();
            CreateMap<Asset, AssetUpdateDto>();

            //Component
            CreateMap<Component, ComponentDto>();
            CreateMap<Component, ComponentCreateDto>();
            CreateMap<Component, ComponentUpdateDto>();

            //Maintenance
            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<Maintenance, MaintenanceCreateDto>();
            CreateMap<Maintenance, MaintenanceUpdateDto>();

            //Depreciation
            CreateMap<Depreciation, DepreciationDto>();
            CreateMap<Depreciation, DepreciationCreateDto>();
            CreateMap<Depreciation, DepreciationUpdateDto>();
        }
    }
}
