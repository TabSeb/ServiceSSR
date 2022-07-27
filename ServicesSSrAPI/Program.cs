using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceSSRContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ServiceSSRConecction"))
);

var app = builder.Build();

//Creacion de Base de datos(code first): No ejecutar si ya estan las tablas creadas
/*using (var scope = app.Services.CreateScope()){

    var context = scope.ServiceProvider.GetRequiredService<ServiceSSRContext>();
    context.Database.Migrate();

}*/

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
