using FluentValidation.AspNetCore;
using FluentValidation;
using static GlobalBlue.Tax.Api.TaxModel;
using GlobalBlue.Tax.BusinessLayer;

namespace GlobalBlue.Tax.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IValidator<TaxModel>, TaxValidator>();
        builder.Services.AddFluentValidationAutoValidation(options => { });
        builder.Services.AddControllers();
        builder.Services.AddTransient<ITaxService, TaxService>();
        AutoMapper.MapperConfiguration mapperConfiguration = new(mc =>
        {
            mc.AddProfile(new TaxProfile());
        });
        builder.Services.AddSingleton(mapperConfiguration.CreateMapper());
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
    }
}