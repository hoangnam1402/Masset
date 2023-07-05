using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.ComponentDtos;

namespace Contracts.Dtos
{
    public class ListResponseDto : BaseResponseDto
    {
        public int[]? Id { get; set; }
        public string[]? Name { get; set; }
        public AssetResponseDto[]? Asset { get; set; }
        public ComponentResponseDto[]? Component { get; set; }
    }
}
