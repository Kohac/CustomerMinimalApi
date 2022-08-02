using CustomerMinimalApiWS.Context;
using CustomerMinimalApiWS.Models;
using CustomerMinimalApiWS.Repository.EntityRepositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CustomerMinimalApiWS.EndpointDefinitions
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("customer"));
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerDto>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressDto>());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
