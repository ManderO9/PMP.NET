namespace PMP.Data
{
    public class Choix : BaseModel
    {
        public int Priorite { get; set; }

        public DateTimeOffset DateEnvoi { get; set; }

        public string ThemeId { get; set; }

        public string EquipeId { get; set; }


        public Theme Theme { get; set; }
        public Equipe Equipe { get; set; }


    }
}