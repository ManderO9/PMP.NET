namespace PMP.Data
{
    public class Invitation : BaseModel
    {
        public StatusInvitation Status { get; set; }

        public DateTimeOffset DateEnvoi { get; set; }

        public AppUser Receiver { get; set; }
        public Equipe InvitingTeam{ get; set; }

        public string EquipeId { get; set; }
    }
}