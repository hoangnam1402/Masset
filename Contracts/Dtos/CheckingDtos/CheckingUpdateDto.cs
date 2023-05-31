using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos.CheckingDtos
{
    public class CheckingUpdateDto
    {
        public int? Quantity { get; set; }
        public int? AssetID { get; set; }
        public int? ComponentID { get; set; }
        public DateTime? CheckDay { get; set; }
    }
}
