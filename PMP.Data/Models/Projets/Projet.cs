namespace PMP.Data
{
    public class Projet : BaseModel
    {
        public string EncadreurId { get; set; }
            
        public string ThemeId { get; set; }

        public string EquipeId { get; set; }
            
        public AppUser Encadreur { get; set; }
        public Theme Theme { get; set; }
        
        public Equipe Equipe { get; set; }

        public List<Livrable> Livrables { get; set; }


    }
}