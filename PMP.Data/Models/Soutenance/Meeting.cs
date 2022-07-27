namespace PMP.Data
{
    public class Meeting : BaseModel
    {
        public DateTimeOffset Date { get; set; }

        public Salle Salle { get; set; }
        
        public PvMeeting PvMeeting { get; set; }

        public AppUser Encadreur { get; set; }
        public Projet Projet { get; set; }

        public string SalleId { get; set; }
        
        public string PvMeetingId { get; set; }

        public string EncadreurId { get; set; }

        public string ProjetId { get; set; }


    }
}