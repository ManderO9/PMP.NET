using Microsoft.EntityFrameworkCore;
using PMP.Data;

namespace PMP.Web
{
    /// <summary>
    /// A helper class to configure the database tables
    /// </summary>
    public static class DatabaseConfiguration
    {
        /// <summary>
        /// Configures the <see cref="AppUser"/> table
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureUsers(this ModelBuilder modelBuilder)
        {
            // Configure the unique ID
            modelBuilder.Entity<AppUser>().Property(u => u.EquipeId).IsRequired(false);

            // Give the student a team, with a foreign key EquipeId having the id of that team
            modelBuilder.Entity<AppUser>().HasOne<Equipe>().WithMany(e => e.Membres).HasForeignKey(u => u.EquipeId);

            // Give the user a list of invitations that he can receive, and give each team a list of invitations that he can send
            modelBuilder.Entity<AppUser>().HasMany(u => u.EquipeInvitations).WithMany(e => e.MembresInvite).UsingEntity<Invitation>();

            // Give default value to non-nullable fields
            modelBuilder.Entity<AppUser>().Property(e => e.CanBeEncadreur).HasDefaultValue(false);
            modelBuilder.Entity<AppUser>().Property(e => e.Moyenne).HasDefaultValue(0);
            modelBuilder.Entity<AppUser>().Property(e => e.CanBeJury).HasDefaultValue(false);
            modelBuilder.Entity<AppUser>().Property(e => e.Grade).HasDefaultValue(Grade.None);
            
            // Configure non required fields
            modelBuilder.Entity<AppUser>().Property(e => e.Specialite).IsRequired(false).HasMaxLength(256);
            modelBuilder.Entity<AppUser>().Property(e => e.Address).IsRequired(false).HasMaxLength(256);
            modelBuilder.Entity<AppUser>().Property(e => e.Domaine).IsRequired(false).HasMaxLength(256);
            modelBuilder.Entity<AppUser>().Property(u => u.EquipeId).IsRequired(false);

            // Return the model builder to continue configuration
            return modelBuilder;
        }

        /// <summary>
        /// Configures the <see cref="Theme"/> table
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureThemes(this ModelBuilder modelBuilder)
        {
            // Give it a unique id
            modelBuilder.Entity<Theme>().HasKey(x => x.Id);

            // Give the theme a promo, with the property PromoId as a foreign key that references the promo
            modelBuilder.Entity<Theme>().HasOne(t => t.Promo).WithMany().HasForeignKey(t => t.PromoId);
            
            // Give the theme a creator id, which can be either a teacher or an entreprise, with CreatorId as a foreign key
            modelBuilder.Entity<Theme>().HasOne(t => t.Creator).WithMany().HasForeignKey(t => t.CreatorId);

            // Configure the themes properties
            modelBuilder.Entity<Theme>().Property(t=>t.Status).HasDefaultValue(Status.PasEncore);
            modelBuilder.Entity<Theme>().Property(t => t.Description).IsRequired(true).HasMaxLength(8192);
            modelBuilder.Entity<Theme>().Property(t => t.MotsCles).IsRequired(false).HasMaxLength(1024);
            modelBuilder.Entity<Theme>().Property(t => t.Titre).IsRequired(true).HasMaxLength(256);

            // Return the model builder to continue configuration
            return modelBuilder;
        }

        /// <summary>
        /// Configures the <see cref="Soutenance"/> table, <see cref="PvSoutenance"/> table, and <see cref="Choix"/> table
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureSoutenances(this ModelBuilder modelBuilder)
        {
            // Give it a unique ID
            modelBuilder.Entity<Soutenance>().HasKey(x => x.Id);

            // Give each soutenance one project, with a foreign key to point to that project
            modelBuilder.Entity<Soutenance>().HasOne(s => s.Projet).WithOne().HasForeignKey<Soutenance>(s => s.ProjetId).OnDelete(DeleteBehavior.NoAction);
          
            // Give each soutenance one salle where it's gonna happen, with a foreign key to point to it
            modelBuilder.Entity<Soutenance>().HasOne(s => s.Salle).WithMany().HasForeignKey(s => s.SalleId);
           
            // Give each soutenance many Jurys, each Jury having many soutenances,
            // using the table Jury to configure the many-to-many relationship
            modelBuilder.Entity<Soutenance>().HasMany(s => s.Jurys).WithMany(u => u.Soutenances).UsingEntity<Jury>();

            // Give a key to the Pv Soutenance table
            modelBuilder.Entity<PvSoutenance>().HasKey(x => x.Id);
            
            // Give it a reference to the Soutenance table, each soutenance is gonna have one pv soutenance
            modelBuilder.Entity<PvSoutenance>().HasOne(p => p.Soutenance).WithOne(s => s.PvSoutenance).HasForeignKey<PvSoutenance>(s => s.SoutenanceId);

            // Give the Jury table a unique key
            modelBuilder.Entity<Jury>().HasKey(x => x.Id);

            // Configure pv soutenance properties
            modelBuilder.Entity<PvSoutenance>().Property(p => p.note).IsRequired(true);
            modelBuilder.Entity<PvSoutenance>().Property(p => p.resume).IsRequired(true).HasMaxLength(16384);

            // Configure the Soutenances properties
            modelBuilder.Entity<Soutenance>().Property(s => s.DateAuthorisation).HasDefaultValue(DateTimeOffset.MinValue);
            modelBuilder.Entity<Soutenance>().Property(s => s.DateSoutenance).HasDefaultValue(DateTimeOffset.MinValue);
            modelBuilder.Entity<Soutenance>().Property(s => s.Duree).IsRequired(true);

            // Return the model builder to continue configuration
            return modelBuilder;
        }

        /// <summary>
        /// Configures the <see cref="Livrable"/> table and the <see cref="Commentaire"/> table
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureLivrables(this ModelBuilder modelBuilder)
        {
            // Give it a unique id
            modelBuilder.Entity<Livrable>().HasKey(x => x.Id);
        
            // Give each livrable one project, and each project many livrables, with ProjetId being the foreign key that will point to the project
            modelBuilder.Entity<Livrable>().HasOne(l => l.Projet).WithMany(p => p.Livrables).HasForeignKey(l => l.ProjetId).OnDelete(DeleteBehavior.NoAction);
            
            // Give it a unique id
            modelBuilder.Entity<Commentaire>().HasKey(x => x.Id);
            // Give each livrable many comments, with LivrableId being the foreign key for the relationship
            modelBuilder.Entity<Commentaire>().HasOne(c => c.Livrable).WithMany().HasForeignKey(c => c.LivrableId).OnDelete(DeleteBehavior.NoAction);

            // Give each comment a creator, and each creator multiple comments, with CreatorId being the foreign key that points to the creator
            modelBuilder.Entity<Commentaire>().HasOne(c => c.Creator).WithMany().HasForeignKey(c => c.CreatorId);

            // Configure Commentaires properties
            modelBuilder.Entity<Commentaire>().Property(c => c.Content).IsRequired(true).HasMaxLength(16384);

            // Configure the Librable properties
            modelBuilder.Entity<Livrable>().Property(l => l.Lien).IsRequired(true).HasMaxLength(512);
            modelBuilder.Entity<Livrable>().Property(l => l.Titre).IsRequired(true).HasMaxLength(256);

            // Return the model builder to continue configuration
            return modelBuilder;
        }

        /// <summary>
        /// Configures the <see cref="Theme"/> table, <see cref="Choix"/> table and <see cref="Invitation"/> table
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureEquipesChoixInvitations(this ModelBuilder modelBuilder)
        {
            // Give it a unique key
            modelBuilder.Entity<Equipe>().HasKey(x => x.Id);
            // Give each team a team leader, with ChefEquipe being the foreign key that will point to that user
            modelBuilder.Entity<Equipe>().HasOne(e => e.ChefEquipe).WithOne().HasForeignKey<Equipe>(e => e.ChefEquipeId);

            // Give each team a list of memebers, and each member one team, with EquipeId being the foreing key for that relationship
            modelBuilder.Entity<Equipe>().HasMany(e => e.Membres).WithOne().HasForeignKey(u => u.EquipeId);

            // Give each team a list of invited users, and each user a list of invitations
            // using the Invitation table to make the many-to-many relationship
            modelBuilder.Entity<Equipe>().HasMany(e => e.MembresInvite).WithMany(u => u.EquipeInvitations).UsingEntity<Invitation>();
          
            // Each team has a list of choices that they can make, choosing a theme in their wishlist, a theme can be chosen by many teams,
            // using the Choix table to make the many-to-many relationship
            modelBuilder.Entity<Equipe>().HasMany(e => e.Choix).WithMany(t => t.EquipesQuiOntChoisisLeTheme).UsingEntity<Choix>();

            // Give the Choix table a unique Id
            modelBuilder.Entity<Choix>().HasKey(x => x.Id);

            // TODO: search for a fix
            // This is not really needed cuz we configured the many-to-many relationship above, but didn't know how to add OnDelete(NoAction),
            // so added these two lines to fix it, need to find another way to add this somewhere else
            modelBuilder.Entity<Choix>().HasOne(c => c.Equipe).WithMany().HasForeignKey(c => c.EquipeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Choix>().HasOne(c => c.Theme).WithMany().HasForeignKey(c => c.ThemeId).OnDelete(DeleteBehavior.NoAction);

            // Give the invitation table a unique Key
            modelBuilder.Entity<Invitation>().HasKey(x => x.Id);

            // Configure Invitation properties
            modelBuilder.Entity<Invitation>().Property(i => i.Status).HasDefaultValue(StatusInvitation.envoye);
            modelBuilder.Entity<Invitation>().Property(i => i.DateEnvoi).IsRequired(true);

            // Configure Choix properties
            modelBuilder.Entity<Choix>().Property(c => c.Priorite).IsRequired(true).HasDefaultValue(int.MinValue);
            modelBuilder.Entity<Choix>().Property(c => c.DateEnvoi).IsRequired(true);

            // Return the model builder to continue configuration
            return modelBuilder;
        }
        
        /// <summary>
        /// Configures the <see cref="Projet"/>, <see cref="Meeting"/> and <see cref="PvMeeting"/> tables
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureProjects(this ModelBuilder modelBuilder)
        {
            // Give Unique Key to tables
            modelBuilder.Entity<Projet>().HasKey(x => x.Id);
            modelBuilder.Entity<Meeting>().HasKey(x => x.Id);
            modelBuilder.Entity<Tache>().HasKey(x => x.Id);
            modelBuilder.Entity<PvMeeting>().HasKey(x => x.Id);
            
            // Give each project a one theme, with each theme being taken by multiple projects, with ThemeId being the foreign key
            modelBuilder.Entity<Projet>().HasOne(p => p.Theme).WithMany().HasForeignKey(p => p.ThemeId).OnDelete(DeleteBehavior.NoAction);
           
            // Give each project one Encadreur, with each encadtreur having multiple projects,
            // and setting EncadreurId to be the foreign key for this relationship
            modelBuilder.Entity<Projet>().HasOne(p => p.Encadreur).WithMany().HasForeignKey(p => p.EncadreurId);

            // Give each project one team, and each team one project, with EquipeId being the foreign key
            modelBuilder.Entity<Projet>().HasOne(p => p.Equipe).WithOne(e => e.Projet).HasForeignKey<Projet>(p => p.EquipeId).OnDelete(DeleteBehavior.NoAction);

            // Give each meeting a project that is associated to, and many meeting for one project, with ProjetId being the foreign key
            modelBuilder.Entity<Meeting>().HasOne(m => m.Projet).WithMany().HasForeignKey(m => m.ProjetId).OnDelete(DeleteBehavior.NoAction);

            // Give each meeting one pv meeting
            modelBuilder.Entity<Meeting>().HasOne(m => m.PvMeeting).WithOne(pv => pv.Meeting).HasForeignKey<Meeting>(m => m.PvMeetingId);

            // Give each meeting one encadreur that did it, with EncadreurId being the foreign key
            modelBuilder.Entity<Meeting>().HasOne(m => m.Encadreur).WithMany().HasForeignKey(m => m.EncadreurId);

            // Give each meeting a salle where it happened
            modelBuilder.Entity<Meeting>().HasOne(m => m.Salle).WithMany().HasForeignKey(m => m.SalleId);

            // Give each Pv Meeting multiple tasks that need to be done
            modelBuilder.Entity<Tache>().HasOne(t => t.PvMeeting).WithMany().HasForeignKey(t => t.PvMeetingId);

            // Configure Tache properties
            modelBuilder.Entity<Tache>().Property(t => t.DateDebut).HasDefaultValue(DateTimeOffset.MinValue);
            modelBuilder.Entity<Tache>().Property(t => t.DateFin).IsRequired();

            // Configure the Meeting properties
            modelBuilder.Entity<Meeting>().Property(m => m.Date).IsRequired(true);

            // Configure pv meeting properties
            modelBuilder.Entity<PvMeeting>().Property(p => p.Description).HasMaxLength(16384).IsRequired();

            // Return the model builder to continue configuration
            return modelBuilder;
        }
         
        /// <summary>
        /// Configures the remaining tables, <see cref="Promo"/>, <see cref="Salle"/>
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure</param>
        /// <returns></returns>
        public static ModelBuilder ConfigureOther(this ModelBuilder modelBuilder)
        {
            // Give unique key to tables
            modelBuilder.Entity<Promo>().HasKey(x => x.Id);
            modelBuilder.Entity<Salle>().HasKey(x => x.Id);

            // Configure Promos properties
            modelBuilder.Entity<Promo>().Property(p => p.Niveau).HasDefaultValue(Niveau.PremiereCPI);
            modelBuilder.Entity<Promo>().Property(p => p.Year).IsRequired(true);
            modelBuilder.Entity<Promo>().Property(p => p.Filiere).HasDefaultValue(Filiere.TrancCommnun);
            modelBuilder.Entity<Promo>().Property(p => p.MaxMembreParEquipe).IsRequired(true);
            modelBuilder.Entity<Promo>().Property(p => p.MaxNombreEquipesParTheme).IsRequired(true);
            modelBuilder.Entity<Promo>().Property(p => p.MaxNombreChoix).IsRequired();

            // Configure Salles properties
            modelBuilder.Entity<Salle>().Property(s => s.Name).IsRequired().HasMaxLength(128);

            // Return the model builder to continue configuration
            return modelBuilder;
        }

    }
}
