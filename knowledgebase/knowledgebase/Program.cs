using knowledgebase.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<knowledgebaseDbSettings>(builder.Configuration.GetSection("knowledgebaseDbSettings"));
builder.Services.AddSingleton<knowledgebaseService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();


app.MapGet("/", () => "Knowledge Base API");

app.MapGet("/api/knowledgebase", async(knowledgebaseService knowledgebaseService) => await knowledgebaseService.Get());

app.MapGet("/api/knowledgebase/{id}", async (knowledgebaseService knowledgebaseService, string id) =>
{
    var knowledgebase = await knowledgebaseService.Get(id);
    return knowledgebase is null ? Results.NotFound() : Results.Ok(knowledgebase);
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();
