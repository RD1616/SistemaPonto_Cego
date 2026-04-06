using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaPontoCego.Infrastructure.Data;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=   COLOCAR O CAMINHO NA AULA     ;Trusted_Connection=True;"));

var provider = services.BuildServiceProvider();