using Microsoft.EntityFrameworkCore;
using ModelsLayer.Context;
using ServiceLayer.Classes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ScheduleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "noArea",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
