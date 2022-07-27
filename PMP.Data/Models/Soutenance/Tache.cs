namespace PMP.Data
{
    public class Tache : BaseModel
    {
        public DateTimeOffset DateDebut { get; set; }

        public DateTimeOffset DateFin { get; set; }


        public string PvMeetingId { get; set; }

        public PvMeeting PvMeeting { get; set; }

    }
}