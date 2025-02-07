var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
