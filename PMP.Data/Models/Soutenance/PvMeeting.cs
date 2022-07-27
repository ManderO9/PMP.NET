namespace PMP.Data
{
    public class PvMeeting : BaseModel
    {
        public string Description { get; set; }

        public int PourcentageProgres { get; set; } 

        public Meeting Meeting { get; set; }
    }
}