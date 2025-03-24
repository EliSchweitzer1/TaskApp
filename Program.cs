using TaskApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Load config
var env = builder.Environment.EnvironmentName;

// Register service
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Logger.LogInformation("Loaded Environment: {env}", env);
app.Run();
