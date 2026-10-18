using ERegistration.Models;
using ERegistration.Models.Repositories;
using ERegistration.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddDBContext<ERegistrationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ERegistrationDbContext")));

builder.Services.AddScoped<IContractorRepository, ContractorRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IPropertyOwnerRepository, PropertyOwnerRepository>();
builder.Services.AddScoped<ILenderRepository, LenderRepository>();
builder.Services.AddScoped<ITitleCompanyRepository, TitleCompanyRepository>();
builder.Services.AddScoped<INoticeOfCommencementRepository, NoticeOfCommencementRepository>();
builder.Services.AddScoped<ILookupValueRepository, LookupValueRepository>();
builder.Services.AddRazorPages();

//Configure cookie authentication
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", options =>
    {
        options.Cookie.Name = "ERegistrationAuthCookie";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

