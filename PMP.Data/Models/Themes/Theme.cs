using System.ComponentModel.DataAnnotations;

namespace PMP.Data
{
    public class Theme : BaseModel
    {
        [MaxLength(100)]
        public string Titre { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string MotsCles { get; set; }

        public Status Status { get; set; }

        public Promo Promo { get; set; }

        public AppUser Creator { get; set; }

        public string PromoId { get; set; }

        public string CreatorId { get; set; }

        public List<Equipe> EquipesQuiOntChoisisLeTheme { get; set; }
    }
}
