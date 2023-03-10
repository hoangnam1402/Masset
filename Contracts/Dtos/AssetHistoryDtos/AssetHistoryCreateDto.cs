using DataAccess.Enums;

namespace Contracts.Dtos.AssetHistoryDtos
{
    public class AssetHistoryCreateDto
    {
        public int AssetID { get; set; }
        public int UserID { get; set; }
        public AssetHistoryStatusEnums Status { get; set; }
        public string? Note { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }

    }
}
