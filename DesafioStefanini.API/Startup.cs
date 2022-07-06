using System.Linq;
using DesafioStefanini.Application.Pipelines;
using DesafioStefanini.Application.Validators;
using DesafioStefanini.Infra.Ioc;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DesafioStefanini.API
{
    public  class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddInfrastructure(Configuration);
            services.AddControllers();
            services.AddValidatorsFromAssembly(typeof(CreatePersonCommandValidator).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Desafio Stefanini", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchMvc.API v1"));
            }

            app.Use(async (ctx, next) =>
            {
                try
                {
                    await next();
                }
                catch (ValidationException e)
                {
                    var response = ctx.Response;
                    if (response.HasStarted)
                        throw;

                    ctx.RequestServices
                        .GetRequiredService<ILogger<Startup>>()
                        .LogWarning(e, "Invalid data has been submitted");

                    response.Clear();
                    response.StatusCode = 400;
                                       
                    await response.WriteAsJsonAsync(new
                    {
                        Message = "Invalid data has been submitted",
                        ModelState = e.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage)
                    });
                }
            });

            app.UseCors(p=> p.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}