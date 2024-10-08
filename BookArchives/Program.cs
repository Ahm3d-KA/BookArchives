using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookArchives.Areas.Identity.Data;
using BookArchives.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ArchiveUserDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ArchiveUserDbContextConnection' not found.");

builder.Services.AddDbContext<ArchiveUserDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BookArchivesUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ArchiveUserDbContext>();

// creates the database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();