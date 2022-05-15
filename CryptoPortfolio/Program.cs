using CryptoPortfolio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CryptoPortfolioContext") ?? throw new InvalidOperationException("Connection string 'CryptoPortfolioContext' not found.");

builder.Services.AddDbContext<CryptoPortfolioContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CryptoPortfolioContext>(); ;

builder.Services.AddDbContext<CryptoPortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CryptoPortfolioContext") ?? throw new InvalidOperationException("Connection string 'CryptoPortfolioContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    Seeder.Initialize(services);
}

app.MapRazorPages();

//CoinGeckoApi api = new CoinGeckoApi(new CryptoPortfolioContext(new DbContextOptions<CryptoPortfolioContext>()));
//api.CheckForNewCryptos();
app.Run();
