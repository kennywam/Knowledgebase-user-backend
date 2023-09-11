using knowledgebase.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<knowledgebaseDbSettings>(builder.Configuration.GetSection("knowledgebaseDbSettings"));
builder.Services.AddSingleton<knowledgebaseService>();
var app = builder.Build();

app.MapGet("/", () => "Knowledge Base API");

app.MapGet("/api/knowledgebase", async(knowledgebaseService knowledgebaseService) => await knowledgebaseService.Get());

app.Run();
