using Autofac;
using ITServiceAccounting.interfaces;
using ITServiceAccounting.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Регистрируем репозитории

            builder.RegisterType<OrganizationRepositoryStub>()
                   .As<IOrganizationRepository>()
                   .SingleInstance();

            builder.RegisterType<ExecutorRepositoryStub>()
                   .As<IExecutorRepository>()
                   .SingleInstance();

            builder.RegisterType<ServiceRepositoryStub>()
                   .As<IServiceRepository>()
                   .SingleInstance();

            builder.RegisterType<ContractRepositoryStub>()
                   .As<IContractRepository>()
                   .SingleInstance();

            builder.RegisterType<MainForm>();

            return builder.Build();
        }
    }
}
