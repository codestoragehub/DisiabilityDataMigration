﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DisabilityInPortal.ApplicationLayer.Authorization.Behaviors;
using DisabilityInPortal.ApplicationLayer.Authorization.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DisabilityInPortal.ApplicationLayer.Authorization.Extensions.DependencyInjection
{
    public static class AddMediatorAuthorizationExtension
    {
        public static IServiceCollection AddMediatorAuthorization(this IServiceCollection services, Assembly assembly)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));
            AddAuthorizationHandlers(services, assembly);

            return services;
        }

        private static IServiceCollection AddAuthorizationHandlers(IServiceCollection services, Assembly assembly)
        {
            var authHandlerOpenType = typeof(IAuthorizationHandler<>);
            GetTypesAssignableTo(assembly, authHandlerOpenType)
                .ForEach(concreation =>
                {
                    foreach (var implementedInterface in concreation.ImplementedInterfaces)
                    {
                        if (!implementedInterface.IsGenericType)
                            continue;
                        if (implementedInterface.GetGenericTypeDefinition() != authHandlerOpenType)
                            continue;

                        services.AddTransient(implementedInterface, concreation);
                    }
                });

            return services;
        }

        private static List<TypeInfo> GetTypesAssignableTo(Assembly assembly, Type compareType)
        {
            return assembly.DefinedTypes.Where(x => x.IsClass
                                                    && !x.IsAbstract
                                                    && x != compareType
                                                    && x.GetInterfaces()
                                                        .Any(i => i.IsGenericType
                                                                  && i.GetGenericTypeDefinition() == compareType))
                ?.ToList();
        }
    }
}