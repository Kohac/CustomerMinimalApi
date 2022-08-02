using AutoMapper;
using CustomerMinimalApiWS.Entities;
using CustomerMinimalApiWS.Models;
using CustomerMinimalApiWS.Repository.EntityRepositories;
using FluentValidation;
using Serilog;

namespace CustomerMinimalApiWS.EndpointDefinitions
{
    public static class EndpointConfiguration
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapGet("Customer/{id}", GetCustomer).Produces<CustomerDto>().WithTags("Customers");
            app.MapGet("Customers", GetCustomers).Produces<CustomerDto>().WithTags("Customers");
            app.MapGet("Customer/{id}/Addresses", GetAddress).Produces<AddressDto>().WithTags("Addresses");


            app.MapPost("Customer", AddCustomer).Produces<CustomerDto>().WithTags("Customers");
            app.MapPost("Customers", AddCustomers).Produces<CustomerDto>().WithTags("Customers");

            app.MapPut("Customer", UpdateCustomer).Produces<CustomerDto>().WithTags("Customers");

            app.MapDelete("Customer/{id}", RemoveCustomer).Produces<CustomerDto>().WithTags("Customers");
            app.MapDelete("Customers", RemoveRangeCustomers).Produces<CustomerDto>().WithTags("Customers");
        }
        internal static IResult GetAddress(ICustomerRepository repo, int id)
        {
            var result = repo.GetFirstOrDefault(x => x.Id == id);
            return Results.Ok(result.Address);

        }
        internal static IResult AddCustomers(ICustomerRepository repo, IMapper mapper, IEnumerable<CustomerDto> customer)
        {
            try
            {
                var result = mapper.Map<IEnumerable<Customer>>(customer);
                repo.AddRange(result);
                repo.Save();
                return Results.Accepted();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        internal static IResult RemoveRangeCustomers(ICustomerRepository repo, IMapper mapper, IEnumerable<CustomerDto> customer)
        {
            try
            {
                var result = mapper.Map<IEnumerable<Customer>>(customer);
                repo.RemoveRange(result);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        internal static IResult RemoveCustomer(ICustomerRepository repo, IMapper mapper, int id)
        {
            try
            {
                var result = repo.GetFirstOrDefault(x => x.Id == id);
                repo.Remove(result);
                return Results.Accepted($"Customers/{result.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        internal static IResult UpdateCustomer(ICustomerRepository repo, IMapper mapper, CustomerDto customer)
        {
            try
            {
                var result = mapper.Map<Customer>(customer);
                repo.Update(result);
                repo.Save();
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        internal static IResult AddCustomer(ICustomerRepository repo, IMapper mapper, IValidator<CustomerDto> validator, CustomerDto customer)
        {
            try
            {
                var validationResult = validator.Validate(customer);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(x => new { errors = x.ErrorMessage });
                    return Results.BadRequest(errors);
                }
                Customer result = mapper.Map<Customer>(customer);
                repo.Add(result);
                repo.Save();
                return Results.Created($"Customers/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        internal static IResult GetCustomer(ICustomerRepository repo, IMapper mapper, long id)
        {
            var result = repo.GetFirstOrDefault(x => x.Id == id);
            return result is not null ? Results.Ok(mapper.Map<CustomerDto>(result)) : Results.NotFound();
        }
        internal static IResult GetCustomers(ICustomerRepository repo, IMapper mapper, ILogger<CustomerDto> logger)
        {
            logger.LogDebug("watafuck");
            logger.LogError("Something bad happen error");
            var result = repo.GetAll();
            return result is not null ? Results.Ok(mapper.Map<IEnumerable<CustomerDto>>(result)) : Results.NotFound();
        }
    }
}
