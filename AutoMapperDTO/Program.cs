using AutoMapperDTO;
using AutoMapperDTO.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(config =>
    {
        // this is for commands to show up in swagger (Project Properties, output, documentation create projectName.xml, suppress number 1591)
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        config.IncludeXmlComments(xmlPath);
    }); //.AddSwaggerGenNewtonsoftSupport();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
}

var app = builder.Build();
{
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
}


