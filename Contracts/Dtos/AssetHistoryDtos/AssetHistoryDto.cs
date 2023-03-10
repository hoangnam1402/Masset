using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Enums;

namespace Contracts.Dtos.AssetHistoryDtos
{
    public class AssetHistoryDto
    {
        public int Id { get; set; }
        public AssetDto? Asset { get; set; }
        public UserDto? User { get; set; }
        public int AssetID { get; set; }
        public int UserID { get; set; }
        public AssetHistoryStatusEnums Status { get; set; }
        public string? Note { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }

    }
}
