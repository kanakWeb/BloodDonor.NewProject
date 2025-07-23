using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Data.UnitOfWork;
using BloodDonor.NewProject.Mapping;
using BloodDonor.NewProject.Repositories.Implementations;
using BloodDonor.NewProject.Repositories.Interfaces;
using BloodDonor.NewProject.Services.Implementataions;
using BloodDonor.NewProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<BloodDonorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBloodDonorRepository, BloodDonorRepository>();
builder.Services.AddScoped<IBloodDonorService, BloodDonorService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
