namespace PMP.Data
{
    public class Jury : BaseModel
    {
        public RoleJury Role { get; set; }
    
        public string TeacherId { get; set; }

        public string SoutenanceId { get; set; }
    
        public AppUser Teacher { get; set; }
        public Soutenance Soutenance { get; set; }

    
    }
}