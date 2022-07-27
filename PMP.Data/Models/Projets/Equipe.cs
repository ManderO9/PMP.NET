namespace PMP.Data
{
    public class Equipe : BaseModel
    {

        public string ChefEquipeId { get; set; }

        public AppUser ChefEquipe { get; set; }

        public List<AppUser> Membres { get; set; }
   
        public Projet Projet { get; set; }

        public List<AppUser> MembresInvite { get; set; }

        public List<Theme> Choix { get; set; }

    }
}
