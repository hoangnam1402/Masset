using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.ComponentDtos;
using Contracts.Dtos.UserDtos;

namespace Contracts.Dtos.CheckingDtos
{
    public class CheckingDto
    {
        public int Id { get; set; }
        public UserDto? User { get; set; }
        public string? UserID { get; set; }
        public int? Quantity { get; set; }
        public AssetDto? Asset { get; set; }
        public int? AssetID { get; set; }
        public ComponentDto? Component { get; set; }
        public int? ComponentID { get; set; }
        public DateTime? CheckDay { get; set; }
        public bool IsCheckOut { get; set; }
        public bool IsEffective { get; set; }

    }
}
