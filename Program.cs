using JobsApi.Mappings;
using JobsApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IJobService, JobService>(); 
builder.Services.AddScoped<ICompanyService, CompanyService>(); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors((options) => {
    options.AddPolicy("DevCors", (corsBuilder) => {
        // Application React
        corsBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
    options.AddPolicy("ProdCors", (corsBuilder) => {
        corsBuilder.WithOrigins("https://sitedeprod.fr")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configuration environnement de développement
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseCors("ProdCors");
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();

