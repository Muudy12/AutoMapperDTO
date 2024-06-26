﻿namespace AutoMapperDTO.Records.Breakfast
{
    public record UpsertBreakfastRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<string>? Savory { get; set; }
        public List<string>? Sweet { get; set; }
    }
}
