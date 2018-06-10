using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.DTO;
using IdGenerator.Infrastructure.EntityFramework;
using IdGenerator.Infrastructure.Repositories;
using IdGenerator.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IdGenerator.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("IdGenerator.Api")), ServiceLifetime.Transient);

            services.AddSingleton(Configuration);
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddScoped<IFactoryPartsRepository, FactoryPartsRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFactoryService, FactoryService>();
            services.AddScoped<IFactoryPartsService, FactoryPartsService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IdGenerator.Api", Version = "1" });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FactoryParts, UniquePartDto>()
                 .ForMember(m => m.Id, opt => opt.MapFrom(src => src.GenerateUniqueId()));
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().WithExposedHeaders("Location").AllowAnyMethod().AllowCredentials());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 ");
            });


        }
    }
}
