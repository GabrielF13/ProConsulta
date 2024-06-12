namespace ProConsulta.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public ICollection<Scheduling> Schedulers { get; set; } = new List<Scheduling>();
    }
}