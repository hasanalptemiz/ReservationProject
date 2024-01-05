using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using ReservationProject.Context;

var builder = WebApplication.CreateBuilder(args);


//Insert service to the container

builder.Services.AddControllers().AddJsonOptions(x =>
                                             x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddDbContext<ReservationDbContext>();

//Swagger config

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


//HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
