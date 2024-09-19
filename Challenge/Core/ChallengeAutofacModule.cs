using Autofac;
using Business.Commands;
using Business.Decorator;
using Core.Interfaces;
using Data;

namespace Challenge.Core
{
    public class ChallengeAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Setup global DI 
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            // Setup DI for the Core project 
            var coreAssembly = typeof(IEntity).Assembly;
            builder.RegisterAssemblyTypes(coreAssembly).AsImplementedInterfaces();

            // Setup DI for the Business project 
            var businessAssembly = typeof(AddTaskCommand).Assembly;
            builder.RegisterAssemblyTypes(businessAssembly).AsImplementedInterfaces(); 
            builder.RegisterAssemblyTypes(businessAssembly).AsClosedTypesOf(typeof(ICommandHandler<,>));

            // Setup DI for the Data project 
            var dataAssembly = typeof(Crud<>).Assembly;
            builder.RegisterAssemblyTypes(dataAssembly).AsImplementedInterfaces();

            // Add decorator to handle save changes; this will keep business logic from having to handle database save changes 
            // Transaction can be implemented in the same way 
            builder.RegisterGenericDecorator(typeof(SaveChangesHandlerDecorator<,>), typeof(ICommandHandler<,>));
            builder.RegisterGeneric(typeof(Crud<>)).As(typeof(ICrud<>))
                .InstancePerDependency();

            builder.RegisterType<ChallengeDbContext>().InstancePerLifetimeScope();
        }
    }
}
