using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<PetShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<PetShopContext>();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings for unauthorized page
    options.AccessDeniedPath = "/Error/UnAuthorized";
});
var app = builder.Build();

//handeling exceptions in production environment
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Exception");
}
//Handling 404 status code
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error/PageNotFound";
        await next();
    }
});

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
    ctx!.Database.EnsureDeleted();
    ctx!.Database.EnsureCreated();
}

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
}); 

app.Run();
