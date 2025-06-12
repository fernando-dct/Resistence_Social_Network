using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Resistence_Repository;
using Resistence_Web.CustomExceptionMiddleware;
using Resistence_Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllers();
builder.Services.AddDbContext<BaseContext>(options => options.UseInMemoryDatabase("InMemoryProvider"));
builder.Services.ConfigureServices();
builder.Services.AddMvc().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ErrorHandlingFilterAttribute());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisições
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resistence Social Network API");
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
