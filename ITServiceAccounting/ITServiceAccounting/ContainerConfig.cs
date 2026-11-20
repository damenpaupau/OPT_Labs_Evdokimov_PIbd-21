using Autofac;
using ITServiceAccounting.interfaces;
using ITServiceAccounting.Repositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace ITServiceAccounting
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var builder = new ContainerBuilder();

            // Логгер регистрируем как SingleInstance
            builder.RegisterInstance(Log.Logger)
                   .As<ILogger>()
                   .SingleInstance();

            // DataContext — отдельный экземпляр при каждом разрешении зависимости
            builder.RegisterType<DataContext>()
                   .AsSelf()
                   .InstancePerDependency();

            // Репозитории на базе EF Core
            builder.RegisterType<OrganizationRepository>()
                   .As<IOrganizationRepository>()
                   .InstancePerDependency();

            builder.RegisterType<ExecutorRepository>()
                   .As<IExecutorRepository>()
                   .InstancePerDependency();

            builder.RegisterType<ServiceRepository>()
                   .As<IServiceRepository>()
                   .InstancePerDependency();

            builder.RegisterType<ContractRepository>()
                   .As<IContractRepository>()
                   .InstancePerDependency();

            // Формы
            builder.RegisterType<MainForm>();

            return builder.Build();
        }
    }
}