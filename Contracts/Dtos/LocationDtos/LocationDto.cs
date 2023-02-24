﻿namespace Contracts.Dtos.LocationDtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}