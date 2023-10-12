namespace AutoMapperDTO.Models
{
    public class Breakfast
    {
        // With our API models, we don't want the client/users being able to change our property/data for an object after it was created/set
        public Guid Id { get; }
        public string? Name { get; }
        public string? Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModifiedDateTime { get; }
        public List<string>? Savory { get; }
        public List<string>? Sweet { get; }

        public Breakfast(
            Guid id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime,
            List<string> savory,
            List<string> sweet)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory = savory;
            Sweet = sweet;
        }
    }
}
