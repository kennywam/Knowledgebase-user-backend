using IBM.EntityFrameworkCore;
using System.Globalization;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

var defaultCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddCommandLine(args)
    .Build();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CDR_pdf.Data.AppDbContext>(options =>
{
    var gsDataSource = config["Db2Connection:Server"];
    var gsDBName = config["Db2Connection:Database"];
    var gsUid = config["Db2Connection:UserID"];
    var gsPwd = config["Db2Connection:Password"];

    var connectionString = config.GetConnectionString("Db2Connection");

    var connection = "Database=" + gsDBName +
        ";Server=" + gsDataSource +
        ";UserID=" + gsUid +
        ";Password=" + gsPwd +
        ";PersistSecurityInfo=True";

    try
    {
        options.UseDb2(connectionString, p => p.SetServerInfo(IBMDBServerType.AS400, IBMDBServerVersion.AS400_07_02));
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Error configuring DbContext: {ex.Message}");

    }
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();