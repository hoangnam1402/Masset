using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class AssetHistory
    {
        public int Id { get; set; }
        public Asset? Asset { get; set; }
        public User? User { get; set; }
        public int AssetID { get; set; }
        public int UserID { get; set; }
        public AssetHistoryStatusEnums Status { get; set; }
        public string? Note { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
    }
}
