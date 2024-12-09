namespace FinalProjectAPI.Entities
{
    public record Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string CollegeProgram { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;

    }
}
