using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CargoTrackingg.Data;
using CargoTrackingg.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsý
builder.Services.AddDbContext<CargoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Kimlik hizmetlerini ekle
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Burada Identity ayarlarýný özelleþtirebilirsiniz
})
    .AddEntityFrameworkStores<CargoDbContext>()
    .AddDefaultTokenProviders();

// Session middleware'ini ekle
builder.Services.AddDistributedMemoryCache(); // Cache kullanýmý
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true; // Güvenlik amacýyla
});

// MVC servislerini ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseSession();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Session'ý aktif et
app.UseSession();

// Seed Data Eklenmesi
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Personnel rolü ekle
    if (!await roleManager.RoleExistsAsync("Personnel"))
    {
        await roleManager.CreateAsync(new IdentityRole("Personnel"));
    }

    // Test personeli ekle
    // Test personeli ekle
    var personnel = new AppUser
    {
        UserName = "personel1@cargo.com",
        Email = "personel1@cargo.com",
        NormalizedUserName = "PERSONEL1@CARGO.COM",
        NormalizedEmail = "PERSONEL1@CARGO.COM",
        FullName = "John Doe",
        EmailConfirmed = true,
        Role = "Personnel",  // **Role alanýný ekledik**
        SecurityStamp = Guid.NewGuid().ToString(),
        ConcurrencyStamp = Guid.NewGuid().ToString()
    };

    var existingUser = await userManager.FindByEmailAsync(personnel.Email);
    if (existingUser == null)
    {
        var result = await userManager.CreateAsync(personnel, "Test@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(personnel, "Personnel");
        }
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
