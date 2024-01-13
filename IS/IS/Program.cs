using IS.Data;
using IS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Ajoutez le service d'identit� � la collection de services
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Ajoutez les autres services � la collection de services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurez le pipeline de requ�tes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();  

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
