    namespace PMP.Data
{
    public class Livrable : BaseModel
    {
        
        public string Titre { get; set; }   

        public string Lien { get; set; }
    


        public AppUser Creator { get; set; }

        public Projet Projet { get; set; }
    

        public string CreatorId{ get; set; }

        public string ProjetId { get; set; }

    }
}