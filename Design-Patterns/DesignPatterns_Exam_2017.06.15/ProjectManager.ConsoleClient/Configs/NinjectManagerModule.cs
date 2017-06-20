using System.IO;
using System.Linq;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine) && type != typeof(Database) && type != typeof(CachingService))
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            this.Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope().Intercept().With<LogErrorInterceptor>();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            var commandFactoryBinding = Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<CreateProjectCommand>().ToSelf().InSingletonScope();
            this.Bind<CreateTaskCommand>().ToSelf().InSingletonScope();
            this.Bind<CreateUserCommand>().ToSelf().InSingletonScope();
            this.Bind<ListProjectDetailsCommand>().ToSelf().InSingletonScope();
            this.Bind<ListProjectsCommand>().ToSelf().WhenInjectedInto<CacheableCommand>();
            this.Bind<UserValidationException>().ToSelf();
            this.Bind<CacheableCommand>().ToSelf().InSingletonScope();

            this.Bind<ICachingService>().To<CachingService>()
                .InSingletonScope()
                .WithConstructorArgument(configurationProvider.CacheDurationInSeconds);

            Bind<ICommand>().ToMethod(context =>
            {
                string commandName = (string)context.Parameters.First().GetValue(context, null);
                switch(commandName.ToLower())
                {
                    case "createproject":
                    return this.Kernel.Get<CreateProjectCommand>();
                    case "createuser":
                    return this.Kernel.Get<CreateUserCommand>();
                    case "createtask":
                    return this.Kernel.Get<CreateTaskCommand>();
                    case "listprojects":
                    return this.Kernel.Get<ListProjectsCommand>();
                    case "listprojectdetails":
                    return this.Kernel.Get<ListProjectDetailsCommand>();
                    default:
                    throw new UserValidationException("No such command!");  
                }
            })
            .NamedLikeFactoryMethod((ICommandsFactory commandFactory) => commandFactory.GetCommandFromString(null));
        }
    }
}
