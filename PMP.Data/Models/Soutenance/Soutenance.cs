namespace PMP.Data
{
    public class Soutenance : BaseModel
    {
        public DateTimeOffset DateAuthorisation { get; set; }

        public DateTimeOffset DateSoutenance { get; set; }

        public TimeSpan Duree { get; set; }


        public PvSoutenance PvSoutenance { get; set; }
        public Salle Salle { get; set; }
        public Projet Projet { get; set; }
        public List<AppUser> Jurys { get; set; }

        public string SalleId { get; set; }

        public string ProjetId { get; set; }

    }
}