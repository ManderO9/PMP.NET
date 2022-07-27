using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMP.Data;
using PMP.Web;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add app database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=.;Database=PMP;Trusted_Connection=True;"));
//builder.Configuration.GetConnectionString("")


// Add identity
builder.Services.AddIdentity<AppUser, AppRole>()
    // Add identity stores in the entity framework db
    .AddEntityFrameworkStores<ApplicationDbContext>()
    // Add identity token creator
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(3);
    options.LoginPath = Routes.LoginPage;
    options.AccessDeniedPath = Routes.AccessDeniedPage;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

builder.Services.AddAuthorization();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(Routes.ErrorPage);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Order matters, it made me waste 3 days trying to figure out why it isn't working
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
//pattern: "{controller=Home}/{action=Index}/{id?}");

// Get a scope to get the db context
using (var scope = app.Services.CreateScope())
{
    // Get the db context
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

    // If the db context is null
    if (dbContext == null)
        // Alert developper
        Debugger.Break();

    // Otherwise...
    else
    {
    //    // Delete the database
    //    await dbContext.Database.EnsureDeletedAsync();

        // Ensure that it is created
        var created =
            dbContext.Database.EnsureCreated();

        //// If the database has been created newly
        //if (created)
        //{
        //    // Fill the database with some default data
        //    var dbCreation = new DatabaseCreation(dbContext,
        //        scope.ServiceProvider.GetService<RoleManager<AppRole>>(),
        //        scope.ServiceProvider.GetService<UserManager<AppUser>>());
        //    await dbCreation.AddDefaultData();
        //}
    }

}


app.Run();

