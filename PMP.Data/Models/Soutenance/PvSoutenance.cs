namespace PMP.Data
{
    public class PvSoutenance : BaseModel
    {
        public float note { get; set; }

        public string resume { get; set; }

        public Soutenance Soutenance { get; set; }
     
        public string SoutenanceId { get; set; }
    }
}