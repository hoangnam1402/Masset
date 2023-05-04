namespace Contracts.Dtos
{
    public class DashboardDto
    {
        public int TotalAsset { get; set; }
        public int TotalComponent { get; set; }
        public int TotalMaintenance { get; set; }
        public int TotalEmployee { get; set; }
        public int NumberOfStatus1 { get; set; }
        public int NumberOfStatus2 { get; set; }
        public int NumberOfStatus3 { get; set; }
        public int NumberOfStatus4 { get; set; }
        public int NumberOfStatus5 { get; set; }
        public int NumberOfStatus6 { get; set; }
        public IList<NumberOfType> NumberOfTypes { get; set; }

        public DashboardDto()
        {
            NumberOfTypes = new List<NumberOfType>();
        }

        public class NumberOfType
        {
            public string? Name { get; set; }
            public int Count { get; set; }
        }
    }
}
