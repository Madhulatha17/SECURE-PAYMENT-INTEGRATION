using Stripe;
using SecurePaymentIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

StripeConfiguration.ApiKey =
builder.Configuration["Stripe:SecretKey"];

builder.Services.AddSingleton<StripePaymentService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Payment}/{action=Index}/{id?}");

app.Run();
