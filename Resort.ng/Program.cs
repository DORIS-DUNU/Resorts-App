

using Microsoft.EntityFrameworkCore;
using Resort.ng;
using Resort.ng.Data;
using Resort.ng.Repository;
using Resort.ng.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

/*Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.File("log/resortLogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();*/

builder.Services.AddScoped<IResortRepository, ResortRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers(option=>
{ 
   // option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
