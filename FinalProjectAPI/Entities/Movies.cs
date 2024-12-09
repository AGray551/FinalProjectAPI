namespace FinalProjectAPI.Entities
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Release { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string RunTime { get; set; } = string.Empty;
    }
}
