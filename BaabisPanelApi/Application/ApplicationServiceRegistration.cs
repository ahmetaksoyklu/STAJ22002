using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);

        RegisterValidators(services, assembly);
        RegisterPipelineBehaviors(services, assembly);
        RegisterBusinessRules(services, assembly);

        return services;
    }

    private static void RegisterValidators(IServiceCollection services, Assembly assembly)
    {
        Type[] validatorTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("Validator", StringComparison.Ordinal))
            .ToArray();

        foreach (Type validatorType in validatorTypes)
        {
            Type[] interfaces = validatorType.GetInterfaces();
            foreach (Type @interface in interfaces)
            {
                services.AddScoped(@interface, validatorType);
            }

            services.AddScoped(validatorType);
        }
    }

    private static void RegisterPipelineBehaviors(IServiceCollection services, Assembly assembly)
    {
        Type[] behaviorTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("Behavior", StringComparison.Ordinal))
            .ToArray();

        foreach (Type behaviorType in behaviorTypes)
        {
            Type[] behaviorInterfaces = behaviorType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>))
                .ToArray();

            foreach (Type behaviorInterface in behaviorInterfaces)
            {
                services.AddTransient(behaviorInterface, behaviorType);
            }
        }
    }

    private static void RegisterBusinessRules(IServiceCollection services, Assembly assembly)
    {
        Type[] businessRuleTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("BusinessRules", StringComparison.Ordinal))
            .ToArray();

        foreach (Type businessRuleType in businessRuleTypes)
        {
            services.AddScoped(businessRuleType);
        }
    }
}
