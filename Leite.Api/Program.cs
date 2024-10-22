var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
.AddIdentityServerAuthentication("Bearer", options =>
{
    options.ApiName = "LeiteApi";
    options.Authority = "http://localhost:5108";
    options.RequireHttpsMetadata = false; // project only for studies purpose
});

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();