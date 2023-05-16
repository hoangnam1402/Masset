using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos.AssetDtos
{
    public class AssetQueryCriteria : BaseQueryCriteria
    {
        public int[]? State { get; set; }

    }
}
