using Microsoft.AspNetCore.Identity;
using PMP.Data;

namespace PMP.Web
{
    public class DatabaseCreation
    {

        #region Private Members

        /// <summary>
        /// The application db context
        /// </summary>
        private ApplicationDbContext mDbContext { get; set; }

        /// <summary>
        /// The role manager for the application roles
        /// </summary>
        private RoleManager<AppRole> mRoleManager;

        /// <summary>
        /// The user manager to create, delete and get users and manage roles
        /// </summary>
        private UserManager<AppUser> mUserManager { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default contstructor
        /// </summary>
        /// <param name="dbContext">The context to access the database</param>
        /// <param name="roleManager">The role manager, manage roles</param>
        /// <param name="userManager">The user manager to create, delete, search users etc...</param>
        public DatabaseCreation(ApplicationDbContext dbContext, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            // Set private memebers
            mDbContext = dbContext;
            mRoleManager = roleManager;
            mUserManager = userManager;
        }

        #endregion

        /// <summary>
        /// Adds default data to work with in the database
        /// </summary>
        public async Task AddDefaultData()
        {
            // Add all the roles 
            await mRoleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString("N"), Name = RoleType.StudentRole });
            await mRoleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString("N"), Name = RoleType.AdminRole });
            await mRoleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString("N"), Name = RoleType.EntrepriseRole });
            await mRoleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString("N"), Name = RoleType.TeacherRole });

            // Create some users
            var ayoub = new AppUser() { UserName = "ayoub", Email = "ayoub@mail.com" };
            var hossem = new AppUser() { UserName = "hossem", Email = "hossem@mail.com" };
            var admin = new AppUser() { UserName = "admin", Email = "admin@mail.com" };
            var raouf = new AppUser() { UserName = "raouf", Email = "raouf@mail.com" };

            // Add some default users
            await mUserManager.CreateAsync(ayoub, "password");
            await mUserManager.CreateAsync(hossem, "password");
            await mUserManager.CreateAsync(raouf, "password");
            await mUserManager.CreateAsync(admin, "password");

            // Add some roles to the users
            await mUserManager.AddToRoleAsync(ayoub, RoleType.StudentRole);
            await mUserManager.AddToRoleAsync(admin, RoleType.AdminRole);
            await mUserManager.AddToRoleAsync(raouf, RoleType.TeacherRole);
            await mUserManager.AddToRoleAsync(hossem, RoleType.AdminRole);
            await mUserManager.AddToRoleAsync(hossem, RoleType.TeacherRole);

            // Add promos
            var promos = new List<Promo>();

            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.PremiereCPI, Year = 2016, Filiere = Filiere.TrancCommnun });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.DeuxiemeCPI, Year = 2015, Filiere = Filiere.TrancCommnun });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.PremiereCS, Year = 2014, Filiere = Filiere.TrancCommnun });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.DeuxiemeCS, Year = 2013, Filiere = Filiere.ISI });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.DeuxiemeCS, Year = 2013, Filiere = Filiere.SIW });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.TroisiemeCS, Year = 2012, Filiere = Filiere.ISI });
            promos.Add(new Promo() { Id = Guid.NewGuid().ToString("N"), MaxMembreParEquipe = 5, MaxNombreEquipesParTheme = 5, MaxNombreChoix = 5, Niveau = Niveau.TroisiemeCS, Year = 2012, Filiere = Filiere.SIW });
            mDbContext.Promos.AddRange(promos);

            // Add a random Theme
            mDbContext.Themes.Add(new Theme()
            {
                CreatorId = hossem.Id,
                Id = Guid.NewGuid().ToString("N"),
                Description = " some description about the theme that we have created",
                MotsCles = "liste de mots cles mec",
                PromoId = promos.First(p=>p.Niveau == Niveau.DeuxiemeCPI).Id,
                Status = Status.PasEncore,
                Titre = "le titre du theme"
            });

            await mDbContext.SaveChangesAsync();
        }

    }
}
