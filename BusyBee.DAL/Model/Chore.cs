namespace BusyBee.DAL
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public bool Complete { get; set; }
        public string CompletedBy { get; set; }
        public DateTime CompletedDate { get; set; }

        public DateTime UpdatedDate { get; set;  }

        public required string UpdatedBy { get; set; }

        public required string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}