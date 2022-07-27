namespace PMP.Data
{
    public class Promo : BaseModel
    {
        public Niveau Niveau { get; set; }
        public Filiere Filiere { get; set; }
        public int Year { get; set; }
        public int MaxMembreParEquipe { get; set; }
        public int MaxNombreChoix { get; set; }
        public int MaxNombreEquipesParTheme { get; set; }


    }
}
