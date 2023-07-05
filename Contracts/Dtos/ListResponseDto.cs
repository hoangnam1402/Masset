namespace Contracts.Dtos
{
    public class ListResponseDto : BaseResponseDto
    {
        public int[]? Id { get; set; }
        public string[]? Name { get; set; }
        public string[]? Tag { get; set; }
    }
}
