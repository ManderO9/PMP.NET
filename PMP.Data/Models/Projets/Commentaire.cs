namespace PMP.Data
{
    public class Commentaire : BaseModel
    {
        //public Livrable Livrable { get; set; }

        public string Content { get; set; }
 

        public AppUser Creator { get; set; }

        public Livrable Livrable { get; set; }


        public string CreatorId { get; set; }
        
        public string LivrableId { get; set; }

    }
}