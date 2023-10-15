using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations;
using OnlineMuhasebeServer.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallService(builder.Configuration, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExeptionMiddleware();

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var usermanager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!usermanager.Users.Any())
    {
        usermanager.CreateAsync(new AppUser
        {
            UserName = "Fatih",
            Email = "Fatihali@gmail.com",
            Id = Guid.NewGuid().ToString(),
            NameLastName = "Fatih Ali Arik"
        }, "Password12*").Wait();
    }
}

app.Run();
