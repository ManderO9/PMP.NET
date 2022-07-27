using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMP.Data;

namespace PMP.Web
{
    /// <summary>
    /// The db context representing the database our application is gonna use
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The database options to configure the database</param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region Database Tables

        /// <summary>
        /// The table containing all themes
        /// </summary>
        public DbSet<Theme> Themes { get; set; }

        /// <summary>
        /// The table containing all the teams
        /// </summary>
        public DbSet<Equipe> Equipes { get; set; }

        /// <summary>
        /// The table that contains all the promos
        /// </summary>
        public DbSet<Promo> Promos { get; set; }

        /// <summary>
        /// The list of all choices token to fill the wish list
        /// </summary>
        public DbSet<Choix> Choix { get; set; }

        /// <summary>
        /// The invitations sent to students from other students to add them to their team
        /// </summary>
        public DbSet<Invitation> Invitations { get; set; }

        /// <summary>
        /// The things that the students will present to the jury indicating the progress of their project
        /// </summary>
        public DbSet<Livrable> Livrables { get; set; }

        /// <summary>
        /// The comments on specific <see cref="Livrable"/>
        /// </summary>
        public DbSet<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// The projects that the teams have created
        /// </summary>
        public DbSet<Projet> Projets { get; set; }

        /// <summary>
        /// The soutenances that will happen after the projects have finished
        /// </summary>
        public DbSet<Soutenance> Soutenances { get; set; }

        /// <summary>
        /// The pvs that will get created at the end of each <see cref="Soutenance"/>
        /// </summary>
        public DbSet<PvSoutenance> PvSoutenances { get; set; }

        /// <summary>
        /// The sales that the <see cref="Soutenance"/> will happen in
        /// </summary>
        public DbSet<Salle> Salles { get; set; }

        /// <summary>
        /// The meetings the teams have done
        /// </summary>
        public DbSet<Meeting> Meetings { get; set; }

        /// <summary>
        /// The pv that gets created at the end of each <see cref="Meeting"/>
        /// </summary>
        public DbSet<PvMeeting> PvMeetings { get; set; }

        /// <summary>
        /// The Tasks that the team members have to do, they get created at the end of each <see cref="Meeting"/>,
        /// and will get completed by students
        /// </summary>
        public DbSet<Tache> Taches { get; set; }

        /// <summary>
        /// The <see cref="Jury"/>s of each <see cref="Soutenance"/>
        /// </summary>
        public DbSet<Jury> Jurys { get; set; }

        #endregion

        #region Database construction

        // Configure database options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // Configure relationships between tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the different tables in the database
            modelBuilder
                // Configure the users table
                .ConfigureUsers()
                
                // Configure the themes table
                .ConfigureThemes()
                
                // Configure soutenances, Choix
                .ConfigureSoutenances()
                
                // Configure livrables, commentaires
                .ConfigureLivrables()
                
                // Configure Equipes, choix, invitations
                .ConfigureEquipesChoixInvitations()

                // Configure projects, meetings, and pv meetings
                .ConfigureProjects()

                // Configure the other tables: Promos and Salles
                .ConfigureOther();

        }

        #endregion

    }
}
