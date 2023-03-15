using DataAccess.Enums;

namespace Contracts.Dtos.AssetHistoryDtos
{
    public class AssetHistoryCreateDto
    {
        public int AssetID { get; set; }
        public string? UserID { get; set; }
        public AssetHistoryStatusEnums Status { get; set; }
        public string? Note { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }

    }
}
