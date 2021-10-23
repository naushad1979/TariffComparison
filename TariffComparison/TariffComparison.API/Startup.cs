using Click.TariffComparison.API.Filters;
using TariffComparison.Business.Services;
using TariffComparison.DataAccess.Repositories;

namespace TariffComparison.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureLocalServices(services);
            ConfigureSwagger(services);
            ConfigureFilters(services);

            services.AddControllers();            
        }
        private void ConfigureLocalServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "TariffComparison API",
                    Version = "v2",
                    Description = "TariffComparison Service",
                });
            });
        }

        private void ConfigureFilters(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);
        }

        public void Configure(IApplicationBuilder app
                , IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "TariffComparison Service"));

        }
    }
}
