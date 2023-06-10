﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(conf =>
            conf.RegisterServicesFromAssembly(assembly)
        );

        return services;
    }
}
