namespace ProConsulta.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Documentt { get; set; } = null!;
        public string Crm { get; set; } = null!;
        public DateTime DateRegister { get; set; }
        public string CellPhone { get; set; } = null!;

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }
        public ICollection<Scheduling> Schedulers { get; set; } = new List<Scheduling>();
    }
}
