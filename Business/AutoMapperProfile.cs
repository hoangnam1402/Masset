using Contracts.Dtos;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.AssetHistoryDtos;
using Contracts.Dtos.AssetTypeDtos;
using Contracts.Dtos.BrandsDtos;
using Contracts.Dtos.CheckingDtos;
using Contracts.Dtos.ComponentDtos;
using Contracts.Dtos.DepreciationDtos;
using Contracts.Dtos.LocationDtos;
using Contracts.Dtos.MaintenanceDtos;
using Contracts.Dtos.SettingDtos;
using Contracts.Dtos.SupplierDtos;
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

            //AssetType
            CreateMap<AssetTypeDto, AssetType>(memberList: AutoMapper.MemberList.None);
            CreateMap<AssetTypeCreateDto, AssetType>(memberList: AutoMapper.MemberList.None);
            CreateMap<AssetTypeUpdateDto, AssetType>(memberList: AutoMapper.MemberList.None);

            //Brand
            CreateMap<BrandDto, Brands>(memberList: AutoMapper.MemberList.None);
            CreateMap<BrandCreateDto, Brands>(memberList: AutoMapper.MemberList.None);
            CreateMap<BrandUpdateDto, Brands>(memberList: AutoMapper.MemberList.None);

            //Location
            CreateMap<LocationDto, Location>(memberList: AutoMapper.MemberList.None);
            CreateMap<LocationCreateDto, Location>(memberList: AutoMapper.MemberList.None);
            CreateMap<LocationUpdateDto, Location>(memberList: AutoMapper.MemberList.None);

            //Supplier
            CreateMap<SupplierDto, Supplier>(memberList: AutoMapper.MemberList.None);
            CreateMap<SupplierCreateDto, Supplier>(memberList: AutoMapper.MemberList.None);
            CreateMap<SupplierUpdateDto, Supplier>(memberList: AutoMapper.MemberList.None);

            //Setting
            CreateMap<SettingDto, Setting>(memberList: AutoMapper.MemberList.None);
            CreateMap<UpdateSettingDto, Setting>(memberList: AutoMapper.MemberList.None)
                .ForMember(src => src.Logo, act => act.Ignore()).ReverseMap();


            //AssetHistory
            CreateMap<AssetHistoryDto, AssetHistory>(memberList: AutoMapper.MemberList.None);

            //Checking
            CreateMap<CheckingDto, Checking>(memberList: AutoMapper.MemberList.None);
            CreateMap<CheckingCreateDto, Checking>(memberList: AutoMapper.MemberList.None);
            CreateMap<CheckingUpdateDto, Checking>(memberList: AutoMapper.MemberList.None);
        }

        private void FromDataAccessorLayer()
        {
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

            //AssetType
            CreateMap<AssetType, AssetTypeDto>();
            CreateMap<AssetType, AssetTypeCreateDto>();
            CreateMap<AssetType, AssetTypeUpdateDto>();

            //Brand
            CreateMap<Brands, BrandDto>();
            CreateMap<Brands, BrandCreateDto>();
            CreateMap<Brands, BrandUpdateDto>();

            //Location
            CreateMap<Location, LocationDto>();
            CreateMap<Location, LocationCreateDto>();
            CreateMap<Location, LocationUpdateDto>();

            //Supplier
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Supplier, SupplierCreateDto>();
            CreateMap<Supplier, SupplierUpdateDto>();

            //Setting
            CreateMap<Setting, SettingDto>();
            CreateMap<Setting, UpdateSettingDto>()
                .ForMember(src => src.Image, act => act.Ignore()).ReverseMap();
        
            //AssetHistory
            CreateMap<AssetHistory, AssetHistoryDto>();

            //Checking
            CreateMap<Checking, CheckingDto>();
            CreateMap<Checking, CheckingCreateDto>();
            CreateMap<Checking, CheckingUpdateDto>();

        }
    }
}
