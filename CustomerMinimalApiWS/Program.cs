var builder = WebApplication.CreateBuilder(args);
builder.ConfigureBuilder();
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();
app.ConfigureEndpoints();

app.Run();