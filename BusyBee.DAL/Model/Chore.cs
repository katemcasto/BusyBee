namespace BusyBee.DAL
{
    public class Chore
    {
        public string? Description { get; set; }

        public bool Complete { get; set; }

        public DateTime UpdatedDate { get; set;  }

        public required string UpdatedBy { get; set; }

        public required string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}