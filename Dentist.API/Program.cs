using Dentist.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

await app.SeedUsers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
